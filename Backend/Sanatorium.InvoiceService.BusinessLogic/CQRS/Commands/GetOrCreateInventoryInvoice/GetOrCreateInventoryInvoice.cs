using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateInventoryInvoice
{
	public class GetOrCreateInventoryInvoice : IRequest<InvoiceDTO>
	{
		public DateOnly DateFrom { get; set; }
	}
}
