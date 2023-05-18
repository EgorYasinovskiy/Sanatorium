using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeManager
{
	public class ChangeManager : IRequest
	{
		public Guid StaffId { get; set; }
		public Guid NewManagerId { get; set; }
	}
}
