using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItem
{
	public class UpdateItem : IRequest
	{
		public UpdateItemDTO UpdateItemDTO { get; set; }
	}
}
