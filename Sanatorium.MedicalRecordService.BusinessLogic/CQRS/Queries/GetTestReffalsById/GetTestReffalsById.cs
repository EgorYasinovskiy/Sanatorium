using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsById
{
	public class GetTestReffalsById : IRequest<TestReffalDTO>
	{
		public Guid Id { get; set; }
	}
}
