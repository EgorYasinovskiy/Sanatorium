using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffInvoice
{
	public class GetStaffInvoice : IRequest<InvoiceDTO>
	{
		public Guid StaffId { get; set; }
		public DateOnly DateFrom { get; set; }
	}
}
