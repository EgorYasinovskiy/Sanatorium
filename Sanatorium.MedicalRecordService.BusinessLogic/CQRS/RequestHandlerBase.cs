using AutoMapper;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected IDiagnosisRepository _diagnosisRepository;
		protected ITestReffalsRepository _testRepository;
		protected IProcedureRepository _procedureRepository;

		protected IMapper _mapper;

		public RequestHandlerBase(IDiagnosisRepository diagnosisRepository, ITestReffalsRepository testRepository, IProcedureRepository procedureRepository, IMapper mapper)
		{
			_diagnosisRepository = diagnosisRepository;
			_testRepository = testRepository;
			_procedureRepository = procedureRepository;
			_mapper = mapper;
		}
	}
}
