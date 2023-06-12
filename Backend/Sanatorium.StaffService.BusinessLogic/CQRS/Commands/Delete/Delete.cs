using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.Delete
{
	public class Delete : IRequest
	{
		public Guid StaffId { get; set; }
	}
}
