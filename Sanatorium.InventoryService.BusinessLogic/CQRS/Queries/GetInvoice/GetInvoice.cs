using MediatR;

using Sanatorium.Common.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoice : IRequest<InvoiceDTO>
	{
	}
}
