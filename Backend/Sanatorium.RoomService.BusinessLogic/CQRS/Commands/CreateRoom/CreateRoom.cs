using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoom
{
	public class CreateRoom : IRequest<RoomDTO>
	{
		public CreateRoomDTO CreateRoomDTO { get; set; }
	}
}
