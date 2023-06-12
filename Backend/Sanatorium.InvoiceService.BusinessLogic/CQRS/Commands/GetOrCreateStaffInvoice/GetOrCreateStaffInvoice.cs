using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateStaffInvoice
{
	public class GetOrCreateStaffInvoice : IRequest<InvoiceDTO>
	{
		public Guid StaffId { get; set; }
		public DateOnly DateFrom { get; set; }
	}
}
