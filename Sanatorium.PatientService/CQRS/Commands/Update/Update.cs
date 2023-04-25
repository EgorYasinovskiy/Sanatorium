using MediatR;

using Sanatorium.PatientService.DTO;

namespace Sanatorium.PatientService.CQRS.Commands.Update
{
	public class Update : IRequest
	{
		public PatientUpdate NewPatient { get; set; }
	}
}
