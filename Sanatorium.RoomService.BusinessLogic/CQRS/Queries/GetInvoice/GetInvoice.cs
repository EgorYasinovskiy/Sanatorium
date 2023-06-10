using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoice : IRequest<InvoiceDTO>
	{
		public Guid PatientID { get; set; }
		public DateOnly From { get; set; }
	}
}
