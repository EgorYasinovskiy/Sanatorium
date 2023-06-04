using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetDiagnosisById
{
	public class GetDiagnosisById : IRequest<DiagnosisDTO>
	{
		public Guid Id { get; set; }
	}
}
