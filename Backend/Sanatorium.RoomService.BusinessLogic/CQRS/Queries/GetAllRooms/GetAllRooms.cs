using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllRooms
{
	public class GetAllRooms : IRequest<RoomListDTO>
	{
	}
}
