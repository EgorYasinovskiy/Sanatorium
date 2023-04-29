using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.Model;

namespace Sanatorium.PatientService.BusinessLogic.Interfaces
{
	public interface IPatientDbContext
	{
		DbSet<Patient> Patients { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
