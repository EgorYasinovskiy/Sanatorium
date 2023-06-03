using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllDiagnosis
{
	public class GetAllDiagnosis : IRequest<DiagnosisListDTO>
	{
	}
}
