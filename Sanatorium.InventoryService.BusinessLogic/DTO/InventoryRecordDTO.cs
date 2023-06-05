using Sanatorium.Common.Mappings;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class InventoryRecordDTO : MapFrom<InventoryHistoryRecord>
	{
		public Guid Id { get; set; }
		public InventoryItemDTO Item { get; set; }
		public int Quantity { get; set; }
		public RecordType RecordType { get; set; }
		public DateTime DateTime { get; set; }
	}
}
