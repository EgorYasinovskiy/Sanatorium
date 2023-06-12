using Sanatorium.Common;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IWorkRecordRepository : IRepositoryBase<WorkRecord>
	{
		public Task<IEnumerable<WorkRecord>> GetByStaffId(Guid staffId, CancellationToken cancellationToken);
		public Task<IEnumerable<WorkRecord>> GetByDateRange(DateOnly from,  DateOnly to, CancellationToken cancellationToken);
		public Task<IEnumerable<WorkRecord>> GetWithCustomFilter(System.Linq.Expressions.Expression<Func<WorkRecord, bool>> filter, CancellationToken token);
	}
}
