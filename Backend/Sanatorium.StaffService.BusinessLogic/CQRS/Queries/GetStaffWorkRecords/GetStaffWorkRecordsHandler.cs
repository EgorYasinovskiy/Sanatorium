using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffWorkRecords
{
	public class GetStaffWorkRecordsHandler : RequestHandlerBase, IRequestHandler<GetStaffWorkRecords, StaffWorkRecordsDTO>
	{
		public GetStaffWorkRecordsHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<StaffWorkRecordsDTO> Handle(GetStaffWorkRecords request, CancellationToken cancellationToken)
		{
			var workRecordsTask = _workRecordRepository.GetByStaffId(request.StaffId, cancellationToken);
			var result = new StaffWorkRecordsDTO();
			result.WorkRecords = _mapper.Map<List<StaffWorkRecordsItem>>(await workRecordsTask);
			return result;
		}
	}
}
