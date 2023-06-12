using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestResult
{
	public class AddTestResultHandler : RequestHandlerBase, IRequestHandler<AddTestResult, TestResultDTO>
	{
		public AddTestResultHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestResultDTO> Handle(AddTestResult request, CancellationToken cancellationToken)
		{
			var result = new TestResult()
			{
				Id = Guid.NewGuid(),
				ResultFile = request.CreateResult.ResultFile,
				TestReffalID = request.CreateResult.TestReffalID,
				TextResult = request.CreateResult.TextResult
			};
			await _testResultsRepository.Create(result, cancellationToken);
			await _testResultsRepository.SaveChanges(cancellationToken);

			return _mapper.Map<TestResultDTO>(result);
		}
	}
}
