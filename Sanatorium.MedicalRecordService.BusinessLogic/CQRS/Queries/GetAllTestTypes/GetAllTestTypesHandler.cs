using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllTestTypes
{
	public class GetAllTestTypesHandler : RequestHandlerBase, IRequestHandler<GetAllTestTypes, TestTypeListDTO>
	{
		public GetAllTestTypesHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestTypeListDTO> Handle(GetAllTestTypes request, CancellationToken cancellationToken)
		{
			var types = await _testTypesRepository.GetAll(cancellationToken);
			var result = new TestTypeListDTO()
			{
				TestTypes = _mapper.Map<IEnumerable<TestTypeDTO>>(types)
			};
			return result;
		}
	}
}
