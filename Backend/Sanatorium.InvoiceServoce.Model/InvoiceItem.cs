namespace Sanatorium.InvoiceService.Model
{
	public class InvoiceItem
	{
		public Guid Id { get; set; }
		public Guid InvoiceId { get; set; }
		public virtual Invoice Invoice { get; set; }
		public string Name { get; set; }
		public int Quanitity { get; set; }
		public double Price { get; set; }
	}
}