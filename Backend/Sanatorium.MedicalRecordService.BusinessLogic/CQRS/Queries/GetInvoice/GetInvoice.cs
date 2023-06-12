using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoice : IRequest<InvoiceDTO>
	{
		public Guid PatientId { get; set; }
		public DateOnly From { get; set; }
	}
}
