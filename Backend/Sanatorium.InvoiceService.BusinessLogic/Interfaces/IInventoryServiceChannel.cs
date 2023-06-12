using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IInventoryServiceChannel
	{
		public Task<InvoiceDTO> GetInvoice(CancellationToken cancellationToken);
	}
}
