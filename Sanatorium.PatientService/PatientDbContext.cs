using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.DataModel;
using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService
{
	public class PatientDbContext : DbContext, IPatientDbContext
	{
		public DbSet<Patient> Patients { get; set; }

		public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }
	}
}
