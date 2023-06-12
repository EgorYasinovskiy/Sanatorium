using AutoMapper;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected IDiagnosisRepository _diagnosisRepository;
		protected IPatientDiagnosisRepository _patientDiagnosisRepository;

		protected ITestReffalsRepository _testRepository;
		protected ITestResultsRepository _testResultsRepository;
		protected ITestTypesRepository _testTypesRepository;

		protected IProcedureReffalsRepository _procedureRepository;
		protected IProcedureTypeRepository _procedureTypeRepository;

		protected IMapper _mapper;

		public RequestHandlerBase(
			IDiagnosisRepository diagnosisRepository,
			IPatientDiagnosisRepository patientDiagnosisRepository,
			ITestReffalsRepository testRepository,
			ITestResultsRepository testResultsRepository,
			ITestTypesRepository testTypesRepository,
			IProcedureReffalsRepository procedureRepository,
			IProcedureTypeRepository procedureTypeRepository,
			IMapper mapper)
		{
			_diagnosisRepository = diagnosisRepository;
			_patientDiagnosisRepository = patientDiagnosisRepository;
			_testRepository = testRepository;
			_testResultsRepository = testResultsRepository;
			_testTypesRepository = testTypesRepository;
			_procedureRepository = procedureRepository;
			_procedureTypeRepository = procedureTypeRepository;
			_mapper = mapper;
		}
	}
}
