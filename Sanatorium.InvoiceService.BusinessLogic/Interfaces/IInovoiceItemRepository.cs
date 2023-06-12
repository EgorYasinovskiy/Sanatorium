using Sanatorium.Common;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IInovoiceItemRepository : IRepositoryBase<InvoiceItem>
	{
		public Task AddRange(IEnumerable<InvoiceItem> invoiceItems, CancellationToken cancellationToken);
	}
}
