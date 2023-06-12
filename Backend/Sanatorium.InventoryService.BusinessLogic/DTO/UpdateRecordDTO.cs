using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class UpdateRecordDTO
	{
		public Guid Id { get; set; }
		public Guid ItemId { get; set; }
		public int Quantity { get; set; }
		public RecordType RecordType { get; set; }
		public DateTime DateTime { get; set; }
	}
}
