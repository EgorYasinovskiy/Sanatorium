using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sanatorium.PatientService.DataModel
{
	public class Patient
	{
		[Key]
		[Required]
		public Guid Id { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "FirstName cannot be empty")]	
		public string FirstName { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "LastName cannot be empty")]
		public string LastName { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "MiddleName cannot be empty")]
		public string MiddleName { get; set; }
		[Required]
		public DateOnly BirthDate { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Phone number cannot be empty")]
		public string PhoneNumber { get; set; }
		[Required]
		public DateOnly DateRegistered { get; set; }
		public DateOnly? DateDischarged { get; set; }
		[Required]
		[DefaultValue(false)]
		public bool Discharged { get; set; }
	}
}