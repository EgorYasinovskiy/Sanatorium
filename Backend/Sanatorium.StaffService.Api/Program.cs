using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.StaffService.Api.Repositories;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<IStaffDbContext, StaffServiceDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("StaffDb"));
			});
			builder.Services.AddScoped<IStaffRepository, StaffRepository>();
			builder.Services.AddScoped<IWorkRecordRepository, WorkRecordsRepository>();
			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IStaffDbContext).Assembly));
			});
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IStaffDbContext).Assembly);
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