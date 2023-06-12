using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class CreateRoomMoveDTO
	{
		public Guid PatientId { get; set; }
		public Guid Room { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }
	}
}
