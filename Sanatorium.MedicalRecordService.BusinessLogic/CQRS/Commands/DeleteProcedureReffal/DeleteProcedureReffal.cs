using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteProcedureReffal
{
	public class DeleteProcedureReffal : IRequest
	{
		public Guid Id { get; set; }
	}
}
