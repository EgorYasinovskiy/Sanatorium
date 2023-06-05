using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryList
{
	public class GetInventoryList : IRequest<InventoryItemListDTO>
	{
	}
}
