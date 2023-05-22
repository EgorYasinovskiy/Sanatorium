namespace Sanatorium.RoomService.Model
{
	public class RoomMoves
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid? OldRoomId { get; set; }
		public Guid? NewRoomId { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }
	}
}
