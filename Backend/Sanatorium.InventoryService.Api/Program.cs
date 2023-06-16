using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.InventoryService.Api.Repositories;
using Sanatorium.InventoryService.BusinessLogic.DTO.ValueResolvers;
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
			builder.Services.AddDateOnlyTimeOnlyStringConverters();
			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IInventoryDbContext).Assembly));
			});
			builder.Services.AddTransient<NeedToByResolver>();
			builder.Services.AddTransient<TotalSumResolver>();
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IInventoryDbContext).Assembly);
			});

			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "InventoryService", Version = "v1" });
			});
			builder.Services.AddOpenApiDocument();
			var app = builder.Build();
			
			// Configure the HTTP request pipeline. 

			
			app.UseSwagger((o)=>o.DocumentName="InventoryServiceApi");
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryService V1");
			});
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}