using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestResult
{
	public class DeleteTestResult : IRequest
	{
		public Guid Id { get; set; }
	}
}
