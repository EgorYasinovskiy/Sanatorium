using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestReffal
{
	public class UpdateTestReffal : IRequest
	{
		public UpdateTestReffalDTO UpdateTestReffalDTO { get;set; }
	}
}
