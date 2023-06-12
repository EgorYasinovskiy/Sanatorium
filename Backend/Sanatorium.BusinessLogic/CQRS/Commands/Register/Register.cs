using MediatR;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.Register
{
	public class Register : IRequest
	{
		public Guid Id { get; set; }
	}
}
