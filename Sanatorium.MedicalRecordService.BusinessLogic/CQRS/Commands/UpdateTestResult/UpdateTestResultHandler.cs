using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestResult
{
	public class UpdateTestResultHandler : RequestHandlerBase, IRequestHandler<UpdateTestResult>
	{
		public UpdateTestResultHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdateTestResult request, CancellationToken cancellationToken)
		{
			var result = await _testResultsRepository.GetById(request.Update.Id, cancellationToken);
			if (result != null)
			{
				result.TextResult = request.Update.TextResult;
				result.ResultFile = request.Update.ResultFile;
				result.TestReffalID = request.Update.TestReffalID;
				
				await _testResultsRepository.Update(result,cancellationToken);
				await _testResultsRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
