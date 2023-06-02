using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.Model;

namespace Sanatorium.PatientService.BusinessLogic.EntityConfigurations.Interfaces
{
	public interface IPatientDbContext
	{
		public DbSet<Patient> Patients { get; set; }
		public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
