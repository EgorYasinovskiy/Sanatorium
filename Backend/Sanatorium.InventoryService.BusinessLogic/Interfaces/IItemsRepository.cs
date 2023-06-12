using Sanatorium.Common;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.Interfaces
{
	public interface IItemsRepository : IRepositoryBase<InventoryItem>
	{
		public Task<IEnumerable<InventoryItem>> GetMissing(CancellationToken cancellationToken);
	}
}
