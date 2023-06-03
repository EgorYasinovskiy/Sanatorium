using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateProcedureType
{
	public class UpdateProcedureType : IRequest
	{
		public UpdateProcedureTypeDTO Update { get; set; }
	}
}
