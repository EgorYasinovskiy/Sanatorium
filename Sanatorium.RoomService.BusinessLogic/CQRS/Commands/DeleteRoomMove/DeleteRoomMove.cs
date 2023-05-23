using MediatR;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoomMove
{
	public class DeleteRoomMove : IRequest
	{
		public Guid Id { get; set; }
	}
}
