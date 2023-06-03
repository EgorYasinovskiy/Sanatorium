using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByType
{
	public class GetProcedureReffalsByType : IRequest<ProcedureReffalsListDTO>
	{
		public Guid ProcedureTypeId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
