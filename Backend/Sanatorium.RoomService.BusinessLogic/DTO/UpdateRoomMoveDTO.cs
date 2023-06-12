using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class UpdateRoomMoveDTO
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid RoomId { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }
	}
}