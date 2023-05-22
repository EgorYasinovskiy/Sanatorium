using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeSchedule
{
	public class ChangeScheduleHandler : RequestHandlerBase, IRequestHandler<ChangeSchedule>
	{
		public ChangeScheduleHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(ChangeSchedule request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
			if (staff != null)
			{
				staff.WorkStart = request.DateStart;
				staff.DayHoliday = request.DayHoliday;
				staff.DayWork = request.DayWork;

				await _staffRepository.Update(staff, cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}

		}
	}
}
