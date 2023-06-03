using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class PatientDiagnosesRepository : IPatientDiagnosisRepository
	{
		private readonly IMedicalRecordsServiceDbContext _context;
		public PatientDiagnosesRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(PatientDaignosis entity, CancellationToken cancellationToken)
		{
			await _context.PatientDaignoses.AddAsync(entity,cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var diagnosis = await _context.PatientDaignoses.FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
			if (diagnosis != null)
			{
				_context.PatientDaignoses.Remove(diagnosis);
			}
		}

		public async Task<IEnumerable<PatientDaignosis>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.PatientDaignoses.Include(x=>x.Diagnosis).ToListAsync(cancellationToken);
		}

		public async Task<PatientDaignosis> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.PatientDaignoses.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public async Task<IEnumerable<PatientDaignosis>> GetByPatientId(Guid patientId, CancellationToken cancellationToken)
		{
			var diagnoses = await _context.PatientDaignoses.Where(x => x.PatientId == patientId).ToListAsync(cancellationToken);
			return diagnoses;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(PatientDaignosis entity, CancellationToken cancellationToken)
		{
			await Task.Run(()=>_context.PatientDaignoses.Update(entity),cancellationToken);
		}
	}
}
