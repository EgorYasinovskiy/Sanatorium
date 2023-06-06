using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordById
{
	public class GetRecordById : IRequest<InventoryRecordDTO>
	{
		public Guid Id { get; set; }	
	}
}
