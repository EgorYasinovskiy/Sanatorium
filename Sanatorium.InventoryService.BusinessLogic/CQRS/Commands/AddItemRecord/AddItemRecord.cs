using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItemRecord
{
	public class AddItemRecord : IRequest<InventoryRecordDTO>
	{
		public CreateRecordDTO CreateRecordDTO { get; set; }
	}
}
