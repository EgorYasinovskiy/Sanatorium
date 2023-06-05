using Microsoft.EntityFrameworkCore;

using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.Interfaces
{
	public interface IInventoryDbContext
	{
		DbSet<InventoryItem> InventoryItems { get; set; }
		DbSet<InventoryHistoryRecord> HistoryRecords { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
