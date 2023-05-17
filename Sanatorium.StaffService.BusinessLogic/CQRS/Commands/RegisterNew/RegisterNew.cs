using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.RegisterNew
{
	public class RegisterNew : IRequest<StaffDTO>
	{
	}
}
