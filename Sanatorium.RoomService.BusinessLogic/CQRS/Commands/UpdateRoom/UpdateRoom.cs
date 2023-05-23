using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoom
{
	public class UpdateRoom : IRequest
	{
		public UpdateRoomDTO UpdateRoomDTO { get; set; }
	}
}
