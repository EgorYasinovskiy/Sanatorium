using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeletePatientDiagnosis
{
	public class DeletePatientDiagnosisHandler : RequestHandlerBase, IRequestHandler<DeletePatientDiagnosis>
	{
		public DeletePatientDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeletePatientDiagnosis request, CancellationToken cancellationToken)
		{
			await _patientDiagnosisRepository.DeleteById(request.Id, cancellationToken);
			await _patientDiagnosisRepository.SaveChanges(cancellationToken);
		}
	}
}
