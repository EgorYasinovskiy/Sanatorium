using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class DiagnosesRepository : IDiagnosisRepository
	{

		private readonly IMedicalRecordsServiceDbContext _context;
		public DiagnosesRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(Diagnosis entity, CancellationToken cancellationToken)
		{
			await _context.Diagnoses.AddAsync(entity,cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var diagnosis = await _context.Diagnoses.FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
			if(diagnosis != null)
			{
				_context.Diagnoses.Remove(diagnosis);
			}
		}

		public async Task<IEnumerable<Diagnosis>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.Diagnoses.ToListAsync(cancellationToken);
		}

		public async Task<Diagnosis> GetById(Guid id, CancellationToken cancellationToken)
		{
			var diagnosis = await _context.Diagnoses.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return diagnosis;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Diagnosis entity, CancellationToken cancellationToken)
		{
			await Task.Run(()=>_context.Diagnoses.Update(entity),cancellationToken);
		}
	}
}
