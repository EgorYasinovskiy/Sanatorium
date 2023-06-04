using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetPacientDiagnosisById
{
	public class GetPacientDiagnosisById : IRequest<PatientDiagnosisDTO>
	{
		public Guid Id { get; set; }
	}
}
