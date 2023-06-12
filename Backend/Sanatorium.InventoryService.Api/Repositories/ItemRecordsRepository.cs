using Microsoft.EntityFrameworkCore;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.Api.Repositories
{
	public class ItemRecordsRepository : IRecordsRepository
	{
		private readonly IInventoryDbContext _context;

		public ItemRecordsRepository(IInventoryDbContext context)
		{
			_context = context;
		}

		public async Task Create(InventoryHistoryRecord entity, CancellationToken cancellationToken)
		{
			await _context.HistoryRecords.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var record = await _context.HistoryRecords.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (record != null)
				_context.HistoryRecords.Remove(record);
		}

		public async Task<IEnumerable<InventoryHistoryRecord>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.HistoryRecords.ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<InventoryHistoryRecord>> GetByDateRange(DateTime from, DateTime to, CancellationToken cancellationToken)
		{
			return await _context.HistoryRecords.Where(x => x.DateTime >= from && x.DateTime <= to).ToListAsync(cancellationToken);
		}

		public async Task<InventoryHistoryRecord> GetById(Guid id, CancellationToken cancellationToken)
		{
			var record = await _context.HistoryRecords.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return record;

		}

		public async Task<IEnumerable<InventoryHistoryRecord>> GetByItem(Guid itemId, CancellationToken cancellationToken)
		{
			return await _context.HistoryRecords.Where(x => x.ItemId == itemId).ToListAsync(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(InventoryHistoryRecord entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.HistoryRecords.Update(entity), cancellationToken);
		}
	}
}
