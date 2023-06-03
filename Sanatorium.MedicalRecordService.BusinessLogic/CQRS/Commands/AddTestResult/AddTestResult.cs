using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestResult
{
	public class AddTestResult : IRequest<TestResultDTO>
	{
		public CreateTestResultDTO CreateResult { get; set; }
	}
}
