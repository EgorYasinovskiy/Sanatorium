using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItemRecord
{
	public class UpdateItemRecord : IRequest
	{
		public UpdateRecordDTO UpdateRecordDTO { get; set; }
	}
}
