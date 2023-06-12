using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IRoomServiceChannel
	{
		public Task<InvoiceDTO> GetInvoice(Guid patientId, DateOnly from, CancellationToken token);
	}
}
