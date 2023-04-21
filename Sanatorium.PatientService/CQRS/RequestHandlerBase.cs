using AutoMapper;

using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands
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
