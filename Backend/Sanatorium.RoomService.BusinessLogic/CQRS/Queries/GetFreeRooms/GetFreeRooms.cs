using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetFreeRooms
{
	public class GetFreeRooms : IRequest<RoomListDTO>
	{
		public DateOnly PeriodStart { get; set; }
		public DateOnly PeriodEnd { get; set; }
	}
}
