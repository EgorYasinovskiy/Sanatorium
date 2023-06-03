using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdatePatientDiagnosis
{
	public class UpdatePatientDiagnosisHandler : RequestHandlerBase, IRequestHandler<UpdatePatientDiagnosis>
	{
		public UpdatePatientDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdatePatientDiagnosis request, CancellationToken cancellationToken)
		{
			var diagnosis = await _patientDiagnosisRepository.GetById(request.UpdatePatientDiagnosisDTO.Id, cancellationToken);
			if (diagnosis != null)
			{
				diagnosis.DiagnosisId = request.UpdatePatientDiagnosisDTO.DiagnosisId;
				diagnosis.Date = request.UpdatePatientDiagnosisDTO.Date;
				diagnosis.PatientId = request.UpdatePatientDiagnosisDTO.PatientId;

				await _patientDiagnosisRepository.Update(diagnosis, cancellationToken);
				await _patientDiagnosisRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
