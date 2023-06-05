using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryResume
{
	public class GetInventoryResume : IRequest<InventoryResumeDTO>
	{
	}
}
