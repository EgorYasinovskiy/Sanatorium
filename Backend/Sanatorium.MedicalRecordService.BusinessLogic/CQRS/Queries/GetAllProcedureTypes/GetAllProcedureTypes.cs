using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllProcedureTypes
{
	public class GetAllProcedureTypes : IRequest<ProcedureTypesListDTO>
	{
	}
}
