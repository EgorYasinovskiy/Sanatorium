using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateProcedureReffal
{
	public class UpdateProcedureReffal : IRequest
	{
		public UpdateProceduralReffalDTO Update { get; set; }
	}
}
