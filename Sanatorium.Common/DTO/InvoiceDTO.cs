namespace Sanatorium.Common.DTO
{
	public class InvoiceDTO
	{
		public Guid Id { get; set; }
		public IEnumerable<InvoiceItemDTO> Items { get; set; }
		public bool Payed { get; set; }
		public DateTime PayDate { get; set; }
	}
}
