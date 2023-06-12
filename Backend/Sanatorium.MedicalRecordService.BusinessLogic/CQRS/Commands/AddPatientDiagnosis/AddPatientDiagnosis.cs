using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddPatientDiagnosis
{
	public class AddPatientDiagnosis : IRequest<PatientDiagnosisDTO>
	{
		public CreatePatientDiagnosisDTO CreatePatientDiagnosisDTO { get; set; }
	}
}
