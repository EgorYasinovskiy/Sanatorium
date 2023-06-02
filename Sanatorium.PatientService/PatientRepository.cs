using Microsoft.EntityFrameworkCore;

using Sanatorium.PatientService.BusinessLogic.EntityConfigurations.Interfaces;
using Sanatorium.PatientService.Model;

namespace Sanatorium.PatientService.Api
{
	public class PatientRepository : IPatientRepository
	{
		private readonly IPatientDbContext _dbContext;

		public PatientRepository(IPatientDbContext dbContext) =>
			_dbContext = dbContext;

		public async Task Create(Patient patient, CancellationToken cancellationToken)
		{
			await _dbContext.Patients.AddAsync(patient, cancellationToken);
		}
		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
			if (patient == null)
				throw new ArgumentException($"Patient with Id {id} was not found");
			_dbContext.Patients.Remove(patient);
		}

		public async Task<IEnumerable<Patient>> GetAll(CancellationToken cancellationToken)
		{
			return await _dbContext.Patients.ToListAsync(cancellationToken);
		}

		public async Task<Patient> GetById(Guid id, CancellationToken cancellationToken)
		{
			var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return patient;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Patient patient, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.Patients.Update(patient));
		}
	}
}
