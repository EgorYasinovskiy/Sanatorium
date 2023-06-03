using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestResultById
{
	public class GetTestResultByIdHandler : RequestHandlerBase, IRequestHandler<GetTestResultById, TestResultDTO>
	{
		public GetTestResultByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestResultDTO> Handle(GetTestResultById request, CancellationToken cancellationToken)
		{
			var testResult = await _testResultsRepository.GetById(request.Id, cancellationToken);

			return testResult == null ? null : _mapper.Map<TestResultDTO>(testResult);
		}
	}
}
