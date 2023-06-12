namespace Sanatorium.InvoiceService.Model
{
	public class Invoice
	{
		public Guid ParentId { get; set; }
		public DateOnly DateFrom { get; set; }
		public Guid Id { get; set; }
		public virtual IEnumerable<InvoiceItem> Items { get; set; }
		public bool Payed { get; set; }
		public DateTime PayDate { get; set; }
	}
}
