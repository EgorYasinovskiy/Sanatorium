namespace Sanatorium.InventoryService.Model
{
	public class InventoryHistoryRecord
	{
		public Guid Id { get; set; }
		public Guid ItemId { get; set; }
		public virtual InventoryItem Item { get; set; }
		public int Quantity { get; set; }
		public RecordType RecordType { get; set; }
		public DateTime DateTime { get; set; }
	}
}