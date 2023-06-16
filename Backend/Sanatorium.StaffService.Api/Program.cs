using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Sanatorium.Common.Mappings;
using Sanatorium.StaffService.Api.Repositories;
using Sanatorium.StaffService.BusinessLogic.DTO.ValueResolvers;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddCors();
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
			builder.Services.AddTransient<ManagerNameValueResolver>();
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IStaffDbContext).Assembly);
			});

			builder.Services.AddControllers();

			builder.Services.AddDateOnlyTimeOnlyStringConverters();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
				cfg.MapType<DateOnly?>(() => new OpenApiSchema { Type = "string", Format = "date" });
				cfg.SwaggerDoc("v1", new OpenApiInfo() { Title = "StaffServiceApi", Version = "v1" });
				cfg.UseDateOnlyTimeOnlyStringConverters();
			});
			builder.Services.AddOpenApiDocument();


			var app = builder.Build();
			app.UseCors(x =>
			{
				x.AllowAnyHeader();
				x.AllowAnyOrigin();
				x.AllowAnyMethod();
			});
			// Configure the HTTP request pipeline.
			app.UseSwagger(o => o.DocumentName = "StaffServiceApi");
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaffServiceApi V1");
			});
			
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}