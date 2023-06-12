namespace Sanatorium.InventoryService.Model
{
	public class InventoryItem
	{
		public Guid Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int RequiredQuantity { get; set; }
	}
}