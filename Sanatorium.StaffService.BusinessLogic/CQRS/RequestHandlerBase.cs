using AutoMapper;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic
{
	public class RequestHandlerBase
	{

		protected IStaffRepository _patientRepository;
		protected IMapper _mapper;

		public RequestHandlerBase(IStaffRepository patientRepository, IMapper mapper)
		{
			_patientRepository = patientRepository;
			_mapper = mapper;
		}
	}
}