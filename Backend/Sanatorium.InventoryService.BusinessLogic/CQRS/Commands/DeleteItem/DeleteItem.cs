using MediatR;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItem
{
	public class DeleteItem : IRequest
	{
		public Guid Id { get; set; }
	}
}
