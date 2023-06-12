using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestResult
{
	public class DeleteTestResultHandler : RequestHandlerBase, IRequestHandler<DeleteTestResult>
	{
		public DeleteTestResultHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeleteTestResult request, CancellationToken cancellationToken)
		{
			await _testResultsRepository.DeleteById(request.Id, cancellationToken);
			await _testResultsRepository.SaveChanges(cancellationToken);
		}
	}
}
