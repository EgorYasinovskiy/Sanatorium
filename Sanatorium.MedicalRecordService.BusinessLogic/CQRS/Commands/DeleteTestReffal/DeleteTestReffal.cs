using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestReffal
{
	public class DeleteTestReffal : IRequest
	{
		public  Guid Id { get; set; }
	}
}
