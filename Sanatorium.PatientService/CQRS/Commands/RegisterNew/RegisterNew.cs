using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew
{
	public class RegisterNew : IRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly BirthDate { get; set; }
	}
}
