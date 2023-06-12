using Microsoft.EntityFrameworkCore;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.Api.Repositories
{
	public class WorkRecordsRepository : IWorkRecordRepository
	{
		private readonly IStaffDbContext _staffDbContext;

		public WorkRecordsRepository(IStaffDbContext staffDbContext)
		{
			_staffDbContext = staffDbContext;
		}
		public async Task Create(WorkRecord workRecord, CancellationToken cancellationToken)
		{
			await _staffDbContext.WorkRecords.AddAsync(workRecord, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var record = await _staffDbContext.WorkRecords.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (record != null)
				_staffDbContext.WorkRecords.Remove(record);
		}

		public async Task<IEnumerable<WorkRecord>> GetAll(CancellationToken cancellationToken)
		{
			return await _staffDbContext.WorkRecords.ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<WorkRecord>> GetByDateRange(DateOnly from, DateOnly to, CancellationToken cancellationToken)
		{
			return await _staffDbContext.WorkRecords.Where(x => x.Date >= from && x.Date <= to).ToListAsync(cancellationToken);
		}

		public async Task<WorkRecord> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _staffDbContext.WorkRecords.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public async Task<IEnumerable<WorkRecord>> GetByStaffId(Guid staffId, CancellationToken cancellationToken)
		{
			return await _staffDbContext.WorkRecords.Where(x => x.StaffId == staffId).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<WorkRecord>> GetWithCustomFilter(System.Linq.Expressions.Expression<Func<WorkRecord, bool>> filter, CancellationToken cancellationToken)
		{
			return await _staffDbContext.WorkRecords.Where(filter).ToListAsync(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _staffDbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(WorkRecord workRecord, CancellationToken cancellationToken)
		{
			if (workRecord != null)
				await Task.Run(() => _staffDbContext.WorkRecords.Update(workRecord));
		}
	}
}
