using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetMissingItems
{
	public class GetMissingItems : IRequest<InventoryItemListDTO>
	{
	}
}
