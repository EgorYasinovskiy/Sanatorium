using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.RegisterNew
{
	public class RegisterNew : IRequest<StaffDTO>
	{
		public CreateStaffDTO CreateStaffDTO { get; set; }
	}
}
