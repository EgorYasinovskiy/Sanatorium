namespace Sanatorium.RoomService.Model
{
	public class RoomMove
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public Guid RoomId { get; set; }
		public virtual Room Room { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }
	}
}
