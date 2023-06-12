namespace Sanatorium.StaffService.BusinessLogic.DTO
{
	public class UpdateStaffDTO
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly Birthdate { get; set; }
	}
}
