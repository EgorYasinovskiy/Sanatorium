namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class UpdateBookingDTO
	{
		public Guid Id { get; set; }
		public Guid RoomId { get; set; }
		public DateOnly ArrivalDate { get; set; }
		public int DurationInDays { get; set; }
	}
}
