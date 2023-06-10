using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IMedicalRecordServiceChannel
	{
		public InvoiceDTO GetInvoice(Guid patientId, DateOnly from);
	}
}
