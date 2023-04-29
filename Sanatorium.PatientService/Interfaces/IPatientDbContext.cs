using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.Interfaces
{
    public interface IPatientDbContext
    {
        DbSet<Patient> Patients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
