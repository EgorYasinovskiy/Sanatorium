namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class CreateItemDTO
	{
		public double Price { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int RequiredQuantity { get; set; }
	}
}
