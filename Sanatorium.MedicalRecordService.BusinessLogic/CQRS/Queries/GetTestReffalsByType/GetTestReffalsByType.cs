using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByType
{
	public class GetTestReffalsByType : IRequest<TestReffalsListDTO>
	{
		public Guid TypeId { get; set; }
		public DateTime Start { get;set; }
		public DateTime End { get; set; }
	}
}
