using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureRefflalById
{
	public class GetProcedureRefflalById : IRequest<ProcedureReffalDTO>
	{
		public Guid Id { get; set; }
	}
}
