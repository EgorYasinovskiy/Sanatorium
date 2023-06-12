using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestResultById
{
	public class GetTestResultById : IRequest<TestResultDTO>
	{
		public Guid Id { get; set; }
	}
}
