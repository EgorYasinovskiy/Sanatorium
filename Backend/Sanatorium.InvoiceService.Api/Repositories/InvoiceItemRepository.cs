using Microsoft.EntityFrameworkCore;

using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.Api.Repositories
{
	public class InvoiceItemRepository : IInovoiceItemRepository
	{
		private readonly IInvoiceDbContext _dbContext;

		public InvoiceItemRepository(IInvoiceDbContext dbContext) { _dbContext = dbContext; }

		public async Task AddRange(IEnumerable<InvoiceItem> invoiceItems, CancellationToken cancellationToken)
		{
			await _dbContext.InvoiceItems.AddRangeAsync(invoiceItems, cancellationToken);
		}

		public async Task Create(InvoiceItem entity, CancellationToken cancellationToken)
		{
			await _dbContext.InvoiceItems.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var e = await _dbContext.InvoiceItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (e != null)
			{
				_dbContext.InvoiceItems.Remove(e);
			}
		}

		public async Task<IEnumerable<InvoiceItem>> GetAll(CancellationToken cancellationToken)
		{
			return await _dbContext.InvoiceItems.ToListAsync(cancellationToken);
		}

		public async Task<InvoiceItem> GetById(Guid id, CancellationToken cancellationToken)
		{
			var e = await _dbContext.InvoiceItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return e;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(InvoiceItem entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => { _dbContext.InvoiceItems.Update(entity); }, cancellationToken);
		}
	}
}
