namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class UpdateRoomDTO
	{
		public Guid Id { get; set; }
		public int Category { get; set; }
		public int BedsCount { get; set; }
		public int RoomNumber { get; set; }
		public bool IsFree { get; set; }
		public double CostPerDay { get; set; }
	}
}
