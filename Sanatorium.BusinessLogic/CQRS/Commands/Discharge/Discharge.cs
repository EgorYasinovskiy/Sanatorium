using MediatR;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.Discharge
{
	public class Discharge : IRequest
	{
		public Guid Id { get; set; }
	}
}