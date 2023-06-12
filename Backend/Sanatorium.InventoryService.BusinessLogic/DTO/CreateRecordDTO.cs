using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class CreateRecordDTO
	{
		public Guid ItemId { get; set; }
		public int Quantity { get; set; }
		public RecordType RecordType { get; set; }
		public DateTime DateTime { get; set; }
	}
}
