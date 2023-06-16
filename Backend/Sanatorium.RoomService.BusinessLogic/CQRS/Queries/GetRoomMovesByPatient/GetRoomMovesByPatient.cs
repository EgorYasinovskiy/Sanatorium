using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMovesByPatient
{
	public class GetRoomMovesByPatient: IRequest<RoomMoveList>
	{
		public Guid PatientId { get; set; }
	}
}
