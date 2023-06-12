using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoomMove
{
	public class UpdateRoomMove : IRequest
	{
		public UpdateRoomMoveDTO UpdateRoomMoveDTO { get; set; }
	}
}
