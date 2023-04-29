namespace Sanatorium.PatientService.BusinessLogic.DTO
{
	public class PatientDTO
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }

		public DateOnly DateRegistered { get; set; }
		public DateOnly? DateDischarged { get; set; }
		public bool Discharged { get; set; }
	}
}
