using AutoMapper;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{

		protected IStaffRepository _staffRepository;
		protected IWorkRecordRepository _workRecordRepository;
		protected IMapper _mapper;

		public RequestHandlerBase(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper)
		{
			_staffRepository = staffRepository;
			_workRecordRepository = workRecordRepository;
			_mapper = mapper;
		}
	}
}