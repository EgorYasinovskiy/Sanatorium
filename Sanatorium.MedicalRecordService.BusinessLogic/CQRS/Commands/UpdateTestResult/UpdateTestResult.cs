using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestResult
{
	public class UpdateTestResult : IRequest
	{
		public UpdateTestResultDTO Update { get; set; }
	}
}
