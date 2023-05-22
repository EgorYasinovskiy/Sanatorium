using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeSchedule
{
	public class ChangeSchedule : IRequest
	{
		public Guid StaffId { get; set; }
		public int DayWork { get; set; }
		public int DayHoliday { get; set; }
		public DateOnly DateStart { get; set; }
	}
}
