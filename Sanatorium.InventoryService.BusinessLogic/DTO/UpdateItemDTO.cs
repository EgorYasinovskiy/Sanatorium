namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class UpdateItemDTO
	{
		public Guid Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int RequiredQuantity { get; set; }
	}
}
