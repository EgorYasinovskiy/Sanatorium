using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestTypeById
{
	public class GetTestTypeById : IRequest<TestTypeDTO>
	{
		public Guid Id { get; set; }
	}
}
