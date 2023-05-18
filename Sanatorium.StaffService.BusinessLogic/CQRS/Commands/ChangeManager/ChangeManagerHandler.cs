using System.Runtime.CompilerServices;

using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeManager
{
	public class ChangeManagerHandler : RequestHandlerBase, IRequestHandler<ChangeManager>
	{
		public ChangeManagerHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(ChangeManager request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
			if (staff != null) 
			{
				staff.ManagerId = request.NewManagerId;
				await _staffRepository.Update(staff,cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
