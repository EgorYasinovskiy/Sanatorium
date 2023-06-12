using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreatePatientInvoice
{
	public class GetOrCreatePatientInvoice : IRequest<InvoiceDTO>
	{
		public Guid PatientId { get; set; }
		public DateOnly DateFrom { get; set; }
		public bool RefreshData { get; set; }
	}
}
