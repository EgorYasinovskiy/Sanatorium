using Microsoft.EntityFrameworkCore;

using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.Api.Repositories
{
	public class InvoiceRepository : IInvoiceRepository
	{
		IInvoiceDbContext _context;
		public InvoiceRepository(IInvoiceDbContext context)
		{
			_context = context;
		}
		public async Task Create(Invoice entity, CancellationToken cancellationToken)
		{
			await _context.Invoices.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var entity = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (entity != null)
				_context.Invoices.Remove(entity);
		}

		public async Task<IEnumerable<Invoice>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.Invoices.ToListAsync(cancellationToken);
		}

		public async Task<Invoice> GetById(Guid id, CancellationToken cancellationToken)
		{
			var entity = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return entity;
		}

		public async Task<Invoice> GetInfoiceByParentIdAndDate(Guid parentid, DateOnly from, CancellationToken cancellationToken)
		{
			var entity = await _context.Invoices.FirstOrDefaultAsync(x => x.ParentId == parentid, cancellationToken);
			return entity;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Invoice entity, CancellationToken cancellationToken)
		{
			await Task.Run(() =>
			{
				_context.Invoices.Update(entity);
			});
		}
	}
}
