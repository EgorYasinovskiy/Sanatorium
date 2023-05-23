using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoomMove
{
	public class CreateRoomMove : IRequest
	{
		public CreateRoomMoveDTO CreateRoomMoveDTO { get; set; }
	}
}
