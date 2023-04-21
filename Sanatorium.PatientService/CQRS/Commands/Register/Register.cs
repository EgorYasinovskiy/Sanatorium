using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.Register
{
    internal class Register : IRequest
    {
        public Guid Id { get; set; }
    }
}
