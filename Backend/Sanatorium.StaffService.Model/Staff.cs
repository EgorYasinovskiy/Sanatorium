namespace Sanatorium.StaffService.Model
{
	public class Staff
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }
		public int CabinetNumber { get; set; }
		public string Position { get; set; }
		public Guid? ManagerId { get; set; }
		public Staff? Manager { get; set; }
		public int DayWork { get; set; }
		public int DayHoliday { get; set; }
		public DateOnly WorkStart { get; set; }
		public double SalaryPerHour { get; set; }
		public virtual List<WorkRecord> WorkRecords { get; set; }

		public string GetDisplayString()
		{
			return $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
		}
	}
}