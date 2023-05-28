namespace Sanatorium.RoomService.Model
{
	public class Booking
	{
		public Guid Id { get; set; }
		public Guid RoomId { get; set; }
		public virtual Room Room { get; set; }
		public DateOnly ArrivalDate { get; set; }
		public int DurationInDays { get; set; }
	}
}
