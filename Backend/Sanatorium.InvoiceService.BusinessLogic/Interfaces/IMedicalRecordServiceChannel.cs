using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IMedicalRecordServiceChannel
	{
		public Task<InvoiceDTO> GetInvoice(Guid patientId, DateOnly from, CancellationToken cancellationToken);
	}
}
