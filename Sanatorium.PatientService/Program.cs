using Microsoft.EntityFrameworkCore;

using Sanatorium.Common.Mappings;
using Sanatorium.PatientService.BusinessLogic.EntityConfigurations.Interfaces;

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

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}