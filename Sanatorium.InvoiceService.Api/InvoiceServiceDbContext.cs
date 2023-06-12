using Microsoft.EntityFrameworkCore;

using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.Api
{
	public class InvoiceServiceDbContext : DbContext, IInvoiceDbContext
	{
		public DbSet<InvoiceItem> InvoiceItems { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
	}
}
