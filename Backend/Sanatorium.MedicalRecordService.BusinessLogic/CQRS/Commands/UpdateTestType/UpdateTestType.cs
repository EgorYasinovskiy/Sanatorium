using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestType
{
	public class UpdateTestType : IRequest
	{
		public UpdateTestTypeDTO UpdateTestTypeDTO { get; set; }
	}
}
