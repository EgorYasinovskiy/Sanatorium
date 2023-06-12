using Microsoft.EntityFrameworkCore;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.Api
{
	public class InventoryDbContext : DbContext, IInventoryDbContext
	{
		public DbSet<InventoryItem> InventoryItems { get; set; }
		public DbSet<InventoryHistoryRecord> HistoryRecords { get; set; }
	}
}
