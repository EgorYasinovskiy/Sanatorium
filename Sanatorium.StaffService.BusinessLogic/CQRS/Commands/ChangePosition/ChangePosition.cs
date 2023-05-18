using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangePosition
{
	public class ChangePosition : IRequest
	{
		public Guid StaffId { get; set; }
		public string NewPosition { get; set; }
	}
}
