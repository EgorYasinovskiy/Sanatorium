using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangePosition
{
	public class ChangePositionHandler : RequestHandlerBase, IRequestHandler<ChangePosition>
	{
		public ChangePositionHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(ChangePosition request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
			if (staff != null)
			{
				staff.Position = request.NewPosition;
				await _staffRepository.Update(staff, cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
