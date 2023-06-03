using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestReffal
{
	public class DeleteTestReffalHandler : RequestHandlerBase, IRequestHandler<DeleteTestReffal>
	{
		public DeleteTestReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeleteTestReffal request, CancellationToken cancellationToken)
		{
			await _testRepository.DeleteById(request.Id,cancellationToken);
			await _testRepository.SaveChanges(cancellationToken);
		}
	}
}
