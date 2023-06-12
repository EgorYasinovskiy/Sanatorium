using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureReffal
{
	public class AddProcedureReffal : IRequest<ProcedureReffalDTO>
	{
		public CreateProceduralReffalDTO CreateProceduralReffalDTO { get; set; }
	}
}
