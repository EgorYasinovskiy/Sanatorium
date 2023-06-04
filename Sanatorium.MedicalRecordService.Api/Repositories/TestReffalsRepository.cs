using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class TestReffalsRepository : ITestReffalsRepository
	{
		private readonly IMedicalRecordsServiceDbContext _context;
		public TestReffalsRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(TestReffal entity, CancellationToken cancellationToken)
		{
			await _context.TestReffals.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var reffals = await _context.TestReffals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (reffals != null)
			{
				_context.TestReffals.Remove(reffals);
			}
		}

		public async Task<IEnumerable<TestReffal>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.TestReffals.ToListAsync(cancellationToken);
		}

		public async Task<TestReffal> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.TestReffals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		}

		public async Task<IEnumerable<TestReffal>> GetByPatientId(Guid patientId, DateTime start, DateTime end, CancellationToken cancellationToken)
		{
			return await _context.TestReffals.Where(x => x.PatientId == patientId && x.DateTime >= start && x.DateTime <= end).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<TestReffal>> GetByTypeId(Guid typeId, DateTime start, DateTime end, CancellationToken cancellationToken)
		{
			return await _context.TestReffals.Where(x => x.TestTypeId == typeId && x.DateTime >= start && x.DateTime <= end).ToListAsync(cancellationToken);

		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(TestReffal entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.TestReffals.Update(entity), cancellationToken);
		}
	}
}
