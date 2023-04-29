using AutoMapper;

using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService.CQRS
{
	public class RequestHandlerBase
	{

		protected IPatientRepository _patientRepository;
		protected IMapper _mapper;

		public RequestHandlerBase(IPatientRepository patientRepository, IMapper mapper)
		{
			_patientRepository = patientRepository;
			_mapper = mapper;
		}
	}
}
