using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.Interfaces
{
	public interface IPatientRepository
	{
		public Task Create(Patient patient, CancellationToken cancellationToken);
		public Task<Patient> GetById(Guid id, CancellationToken cancellationToken);
		public Task<IEnumerable<Patient>> GetAll(CancellationToken cancellationToken);
		public Task DeleteById(Guid id, CancellationToken cancellationToken);
		public Task Update(Patient patient, CancellationToken cancellationToken);
		public Task SaveChanges(CancellationToken cancellationToken);
	}
}
