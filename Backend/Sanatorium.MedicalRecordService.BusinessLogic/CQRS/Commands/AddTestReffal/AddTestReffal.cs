using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestReffal
{
	public class AddTestReffal : IRequest<TestReffalDTO>
	{
		public CreateTestReffalDTO CreateTestReffalDTO { get; set; }
	}
}
