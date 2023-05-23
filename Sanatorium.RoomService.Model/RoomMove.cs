namespace Sanatorium.RoomService.Model
{
	public class RoomMove
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid? OldRoomId { get; set; }
		public virtual Room OldRoom { get; set; }
		public Guid? NewRoomId { get; set; }
		public virtual Room NewRoom { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }
	}
}
