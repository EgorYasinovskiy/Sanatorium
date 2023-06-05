using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetItemById
{
	public class GetItemById : IRequest<InventoryItemDTO>
	{
		public Guid Id { get; set; }
	}
}
