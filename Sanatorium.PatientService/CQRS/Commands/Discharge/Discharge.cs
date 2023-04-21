using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew.Discharge
{
	public class Discharge : IRequest
	{
		public Guid ID { get; set; }
	}
}