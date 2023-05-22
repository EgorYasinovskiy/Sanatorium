using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetAllStaff
{
	public class GetAllStaffHandler : RequestHandlerBase, IRequestHandler<GetAllStaff, StaffList>
	{
		public GetAllStaffHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<StaffList> Handle(GetAllStaff request, CancellationToken cancellationToken)
		{
			var allStaff = await _staffRepository.GetAll(cancellationToken);
			var staffList = new StaffList();
			staffList.Staff = _mapper.Map<List<StaffListItem>>(allStaff);
			return staffList;
		}
	}
}
