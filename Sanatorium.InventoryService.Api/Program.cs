using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.InventoryService.Api.Repositories;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<IInventoryDbContext, InventoryDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("InventoryDb"));
			});
			builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
			builder.Services.AddScoped<IRecordsRepository, ItemRecordsRepository>();
			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IInventoryDbContext).Assembly));
			});
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IInventoryDbContext).Assembly);
			});

			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}