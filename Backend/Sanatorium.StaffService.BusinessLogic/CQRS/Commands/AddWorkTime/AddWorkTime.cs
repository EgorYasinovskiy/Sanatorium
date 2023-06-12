using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.AddWorkTime
{
	public class AddWorkTime : IRequest
	{
		public Guid StaffId { get; set; }
		public double Hours { get; set; }
		public DateOnly Date { get; set; }
	}
}
