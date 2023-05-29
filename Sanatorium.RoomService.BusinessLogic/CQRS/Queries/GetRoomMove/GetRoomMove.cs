using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMove
{
	public class GetRoomMove : IRequest<RoomMoveDTO>
	{
		public Guid Id { get; set; }
	}
}
