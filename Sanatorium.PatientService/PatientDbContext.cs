using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.Api.EntityConfigurations;
using Sanatorium.PatientService.BusinessLogic.Interfaces;
using Sanatorium.PatientService.Model;

namespace Sanatorium.PatientService.Api
{
	public class PatientDbContext : DbContext, IPatientDbContext
	{
		public DbSet<Patient> Patients { get; set; }

		public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PatientConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
