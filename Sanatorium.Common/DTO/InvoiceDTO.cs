namespace Sanatorium.Common.DTO
{
	public class InvoiceDTO
	{
		// Parent can be a patiet,staff, or inventory in case Guid == {7779772A-125B-4E36-A58F-D24EB1494973}
		public Guid ParentId { get; set; }
		public DateOnly DateFrom { get; set; }
		public Guid Id { get; set; }
		public IEnumerable<InvoiceItemDTO> Items { get; set; }
		public bool Payed { get; set; }
		public DateTime PayDate { get; set; }
	}
}
