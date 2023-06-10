using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IRoomServiceChannel
	{
		public InvoiceDTO GetInvoice(Guid patientId, DateOnly from);
	}
}
