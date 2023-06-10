using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByItem
{
	public class GetRecordsByItem : IRequest<InventoryRecordListDTO>
	{
		public Guid ItemId { get; set; }
	}
}
