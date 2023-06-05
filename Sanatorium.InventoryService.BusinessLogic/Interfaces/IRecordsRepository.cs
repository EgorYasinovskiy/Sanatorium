using Sanatorium.Common;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.Interfaces
{
	public interface IRecordsRepository : IRepositoryBase<InventoryHistoryRecord>
	{
		public Task<IEnumerable<InventoryHistoryRecord>> GetByItem(Guid itemId, CancellationToken cancellationToken);
		public Task<IEnumerable<InventoryHistoryRecord>> GetByDateRange(DateTime from, DateTime to, CancellationToken cancellationToken);
	}
}
