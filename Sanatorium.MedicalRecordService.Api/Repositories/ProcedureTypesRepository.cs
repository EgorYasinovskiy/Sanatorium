using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class ProcedureTypesRepository : IProcedureTypeRepository
	{
		private readonly IMedicalRecordsServiceDbContext _context;
		public ProcedureTypesRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(ProcedureType entity, CancellationToken cancellationToken)
		{
			await _context.ProcedureTypes.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var type = await _context.ProcedureTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
			if (type != null)
			{
				_context.ProcedureTypes.Remove(type);
			}
		}

		public async Task<IEnumerable<ProcedureType>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.ProcedureTypes.ToListAsync(cancellationToken);
		}

		public async Task<ProcedureType> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.ProcedureTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(ProcedureType entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.ProcedureTypes.Update(entity), cancellationToken);
		}
	}
}
