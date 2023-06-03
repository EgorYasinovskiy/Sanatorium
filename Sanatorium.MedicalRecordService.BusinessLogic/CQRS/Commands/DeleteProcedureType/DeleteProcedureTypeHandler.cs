using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteProcedureType
{
	public class DeleteProcedureTypeHandler : RequestHandlerBase, IRequestHandler<DeleteProcedureType>
	{
		public DeleteProcedureTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeleteProcedureType request, CancellationToken cancellationToken)
		{
			await _procedureTypeRepository.DeleteById(request.Id,cancellationToken);
			await _procedureTypeRepository.SaveChanges(cancellationToken);
		}
	}
}
