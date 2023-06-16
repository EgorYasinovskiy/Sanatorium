using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Api.Repositories;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<IMedicalRecordsServiceDbContext, MedicalRecordsServiceDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("MedicalRecordsDb"));
			});

			builder.Services.AddScoped<IDiagnosisRepository, DiagnosesRepository>();
			builder.Services.AddScoped<IPatientDiagnosisRepository, PatientDiagnosesRepository>();
			builder.Services.AddScoped<ITestTypesRepository, TestTypesRepository>();
			builder.Services.AddScoped<ITestReffalsRepository, TestReffalsRepository>();
			builder.Services.AddScoped<ITestResultsRepository, TestResultsRepository>();
			builder.Services.AddScoped<IProcedureTypeRepository, ProcedureTypesRepository>();
			builder.Services.AddScoped<IProcedureReffalsRepository, ProcedureReffalsRepository>();
			builder.Services.AddDateOnlyTimeOnlyStringConverters();


			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IMedicalRecordsServiceDbContext).Assembly));
			});

			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IMedicalRecordsServiceDbContext).Assembly);
			});

			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "MedicalRecordsServiceApi", Version = "v1" });
			});
			builder.Services.AddOpenApiDocument();
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseSwagger(o => o.DocumentName = "MedicalRecordsServiceApi");
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalRecordsServiceApi V1");
			});

			// Configure the HTTP request pipeline.

			
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}