using MediatR;

using Sanatorium.PatientService.BusinessLogic.DTO;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.RegisterNew
{
	public class RegisterNew : IRequest<PatientDTO>
	{
		public CreatePatientDTO Patient { get; set; }
	}
}
