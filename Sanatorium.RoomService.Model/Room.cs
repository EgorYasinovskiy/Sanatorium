namespace Sanatorium.RoomService.Model
{
	public class Room
	{
		public Guid Id { get; set; }
		public int Category { get; set; }
		public int BedsCount { get; set; }
		public int RoomNumber { get; set; }
		public bool IsFree { get; set; }
		public double CostPerDay { get; set; }
		public virtual IEnumerable<Booking> Bookings { get; set; }
	}
}