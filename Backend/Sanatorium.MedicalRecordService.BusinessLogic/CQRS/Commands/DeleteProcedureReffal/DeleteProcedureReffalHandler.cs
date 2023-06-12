using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteProcedureReffal
{
	public class DeleteProcedureReffalHandler : RequestHandlerBase, IRequestHandler<DeleteProcedureReffal>
	{
		public DeleteProcedureReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeleteProcedureReffal request, CancellationToken cancellationToken)
		{
			await _procedureRepository.DeleteById(request.Id, cancellationToken);
			await _procedureRepository.SaveChanges(cancellationToken);
		}
	}
}
