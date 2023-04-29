using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.Discharge
{
	public class Discharge : IRequest
	{
		public Guid Id { get; set; }
	}
}