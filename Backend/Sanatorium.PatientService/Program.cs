using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.PatientService.BusinessLogic.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;

namespace Sanatorium.PatientService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<IPatientDbContext, PatientDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("PatientDb"));
			});
			builder.Services.AddScoped<IPatientRepository, PatientRepository>();
			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IPatientDbContext).Assembly));
			});

			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IPatientDbContext).Assembly);
			});

			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "PatientServiceApi", Version = "v1" });
			});
			builder.Services.AddOpenApiDocument();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();
			app.UseSwagger(o =>
			{
				o.DocumentName = "PatientServiceApi";
			});
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientServiceApi V1");
			});
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}