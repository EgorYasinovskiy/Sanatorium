using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByDateRange
{
	public class GetRecordsByDateRange : IRequest<InventoryRecordListDTO>
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
