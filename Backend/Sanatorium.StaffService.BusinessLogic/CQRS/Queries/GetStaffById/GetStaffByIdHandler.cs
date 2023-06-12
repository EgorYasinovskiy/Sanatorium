using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffById
{
	public class GetStaffByIdHandler : RequestHandlerBase, IRequestHandler<GetStaffById, StaffDTO>
	{
		public GetStaffByIdHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<StaffDTO> Handle(GetStaffById request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
			if (staff != null)
			{
				return _mapper.Map<StaffDTO>(staff);
			}
			return null;
		}
	}
}
