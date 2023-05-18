using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeSalary
{
	public class ChangeSalary : IRequest
	{
		public Guid StaffId { get; set; }
		public double NewSalaryPerHour { get; set; }
	}
}
