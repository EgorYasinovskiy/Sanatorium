namespace Sanatorium.InvoiceService.Model
{
	public class Invoice
	{
		public Guid Id { get; set; }
		public virtual IEnumerable<InvoiceItem> Items { get; set; }
		public bool Payed { get; set; }
		public DateTime PayDate { get; set; }
	}
}
