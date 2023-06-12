using Microsoft.EntityFrameworkCore;

using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IInvoiceDbContext
	{
		public DbSet<InvoiceItem> InvoiceItems { get; set; }
		public DbSet<Invoice> Invoices { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
