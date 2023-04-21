using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.Register
{
	public class Register : IRequest
	{
		public Guid Id { get; set; }
	}
}
