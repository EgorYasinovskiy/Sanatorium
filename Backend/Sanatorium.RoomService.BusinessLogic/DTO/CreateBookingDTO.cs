namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class CreateBookingDTO
	{
		public Guid RoomId { get; set; }
		public DateOnly ArrivalDate { get; set; }
		public int DurationInDays { get; set; }
	}
}
