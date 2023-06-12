using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.UpdateWorkTime
{
	public class UpdateWorkTime : IRequest
	{
		public Guid RecordId { get; set; }
		public double Hours { get; set; }
		public DateOnly Date { get; set; }
	}
}
