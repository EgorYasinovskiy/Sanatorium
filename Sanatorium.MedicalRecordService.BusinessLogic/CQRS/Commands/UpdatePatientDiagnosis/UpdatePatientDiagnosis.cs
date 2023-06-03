using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdatePatientDiagnosis
{
	public class UpdatePatientDiagnosis : IRequest
	{
		public UpdatePatientDiagnosisDTO UpdatePatientDiagnosisDTO { get; set; }
	}
}
