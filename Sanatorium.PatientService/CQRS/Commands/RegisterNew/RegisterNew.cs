using MediatR;

using Sanatorium.PatientService.DTO;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew
{
	public class RegisterNew : IRequest
	{
		public CreatePatientDTO Patient { get; set; }
	}
}
