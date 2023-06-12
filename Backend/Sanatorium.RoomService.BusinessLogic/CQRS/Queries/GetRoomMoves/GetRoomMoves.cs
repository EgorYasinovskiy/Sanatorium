using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMoves
{
	public class GetRoomMoves : IRequest<RoomMoveList>
	{
		public Guid PatientId { get; set; }
		public DateOnly PeriodStart { get; set; }
		public DateOnly PeriodEnd { get; set; }
	}
}
