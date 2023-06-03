using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestType
{
	public class DeleteTestType : IRequest
	{
		public Guid Id { get; set; }
	}
}
