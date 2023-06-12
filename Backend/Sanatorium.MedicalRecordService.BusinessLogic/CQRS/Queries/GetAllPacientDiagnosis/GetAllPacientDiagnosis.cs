using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllPacientDiagnosis
{
	public class GetAllPacientDiagnosis : IRequest<PatientDiagnosisListDTO>
	{
		public Guid PatientId { get; set; }
	}
}
