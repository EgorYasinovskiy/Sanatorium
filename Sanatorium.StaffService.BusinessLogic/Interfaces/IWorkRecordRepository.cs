using Sanatorium.Common;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IWorkRecordRepository : IRepositoryBase<WorkRecord>
	{
		public Task<IEnumerable<WorkRecord>> GetByStaffId(Guid staffId, CancellationToken cancellationToken);
	}
}
