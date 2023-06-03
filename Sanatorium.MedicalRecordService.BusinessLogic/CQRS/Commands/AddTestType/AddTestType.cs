using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestType
{
	public class AddTestType : IRequest<TestTypeDTO>
	{
		public CreateTestTypeDTO CreateTestType { get; set; }
	}
}
