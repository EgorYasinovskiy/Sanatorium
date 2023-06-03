using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteProcedureType
{
	public class DeleteProcedureType : IRequest
	{
		public Guid Id { get;set; }
	}
}
