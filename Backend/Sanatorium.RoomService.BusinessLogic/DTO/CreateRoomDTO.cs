namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class CreateRoomDTO
	{
		public int Category { get; set; }
		public int BedsCount { get; set; }
		public int RoomNumber { get; set; }
		public double CostPerDay { get; set; }
	}
}
