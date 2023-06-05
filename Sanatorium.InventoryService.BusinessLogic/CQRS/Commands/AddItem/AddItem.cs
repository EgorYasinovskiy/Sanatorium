using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItem
{
	public class AddItem : IRequest<InventoryItemDTO>
	{
		public CreateItemDTO CreateItemDTO { get; set; }
	}
}
