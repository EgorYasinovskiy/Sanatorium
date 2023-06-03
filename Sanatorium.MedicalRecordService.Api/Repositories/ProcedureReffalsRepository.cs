using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class ProcedureReffalsRepository : IProcedureReffalsRepository
	{
		private readonly IMedicalRecordsServiceDbContext _context;
		public ProcedureReffalsRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(ProcedureReffal entity, CancellationToken cancellationToken)
		{
			await _context.ProcedureReffals.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var reffal = await _context.ProcedureReffals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (reffal != null)
			{
				_context.ProcedureReffals.Remove(reffal);
			}
		}

		public async Task<IEnumerable<ProcedureReffal>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.ProcedureReffals.ToListAsync(cancellationToken);
		}

		public async Task<ProcedureReffal> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.ProcedureReffals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public async Task<IEnumerable<ProcedureReffal>> GetReffalsByPatient(Guid patientId, DateTime start, DateTime end, CancellationToken cancellationToken)
		{
			return await _context.ProcedureReffals.Where(x => x.PatientId == patientId && x.DateTime >= start && x.DateTime <= end).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<ProcedureReffal>> GetReffalsByType(Guid typeId, DateTime start, DateTime end, CancellationToken cancellationToken)
		{
			return await _context.ProcedureReffals.Where(x => x.ProcedureTypeId == typeId && x.DateTime >= start && x.DateTime <= end).ToListAsync(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(ProcedureReffal entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.ProcedureReffals.Update(entity), cancellationToken);
		}
	}
}
