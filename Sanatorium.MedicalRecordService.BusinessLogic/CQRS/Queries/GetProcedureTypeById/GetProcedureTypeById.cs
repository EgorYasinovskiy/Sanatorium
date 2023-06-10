using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureTypeById
{
	public class GetProcedureTypeById : IRequest<ProcedureTypeDTO>
	{
		public Guid Id { get; set; }
	}
}
