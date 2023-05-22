using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.DeleteWorkTime
{
	public class DeleteWorktime : IRequest
	{
		public Guid RecordId { get; set; }
	}
}
