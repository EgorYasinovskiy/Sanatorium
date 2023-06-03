using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureType
{
	public class AddProcedureType :IRequest<ProcedureTypeDTO>
	{
		public CreateProcedureTypeDTO CreateProcedureTypeDTO { get; set; }
	}
}
