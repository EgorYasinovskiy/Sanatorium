using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sanatorium.PatientService.Interfaces;
using Sanatorium.PatientService.Mappings;

namespace Sanatorium.PatientService
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
				cfg.AddProfile(new AssemblyMappingsProfile(Assembly.GetExecutingAssembly()));
			});

			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
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