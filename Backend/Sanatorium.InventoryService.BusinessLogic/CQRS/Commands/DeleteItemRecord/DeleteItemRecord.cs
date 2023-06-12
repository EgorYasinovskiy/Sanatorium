using MediatR;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItemRecord
{
	public class DeleteItemRecord : IRequest
	{
		public Guid Id { get; set; }
	}
}
