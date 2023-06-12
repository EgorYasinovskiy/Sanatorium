using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllTestTypes
{
	public class GetAllTestTypes : IRequest<TestTypeListDTO>
	{
	}
}
