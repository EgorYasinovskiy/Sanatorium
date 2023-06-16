namespace Sanatorium.StaffService.BusinessLogic.DTO
{
	public class CreateStaffDTO
	{
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly BirthDate { get; set; }
		public string Position { get; set; }
		public int DayWork { get; set; }
		public int DayHoliday { get; set; }
		public DateOnly WorkStart { get; set; }
		public Guid? ManagerId { get; set; }
		public double SalaryPerHour { get; set; }
	}
}
