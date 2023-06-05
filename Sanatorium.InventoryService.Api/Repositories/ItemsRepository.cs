using Microsoft.EntityFrameworkCore;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.Api.Repositories
{
	public class ItemsRepository : IItemsRepository
	{
		private readonly IInventoryDbContext _context;

		public ItemsRepository(IInventoryDbContext context)
		{
			_context = context;
		}

		public async Task Create(InventoryItem entity, CancellationToken cancellationToken)
		{
			await _context.InventoryItems.AddAsync(entity,cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var item = await _context.InventoryItems.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
			if (item != null) 
				_context.InventoryItems.Remove(item);
		}

		public async Task<IEnumerable<InventoryItem>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.InventoryItems.ToListAsync(cancellationToken);
		}

		public async Task<InventoryItem> GetById(Guid id, CancellationToken cancellationToken)
		{
			var item = await _context.InventoryItems.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
			return item;
		}

		public async Task<IEnumerable<InventoryItem>> GetMissing(CancellationToken cancellationToken)
		{
			return await _context.InventoryItems.Where(x=>x.Quantity < x.RequiredQuantity).ToListAsync(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(InventoryItem entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.InventoryItems.Update(entity),cancellationToken);
		}
	}
}
