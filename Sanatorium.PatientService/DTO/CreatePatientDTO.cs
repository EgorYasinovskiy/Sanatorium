namespace Sanatorium.PatientService.DTO
{
	public class CreatePatientDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly BirthDate { get; set; }
	}
}
