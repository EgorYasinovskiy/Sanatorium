namespace Sanatorium.StaffService.Model
{
	public class WorkRecord
	{
		public Guid Id { get; set; }
		public DateOnly Date { get; set; }
		public double Hours { get; set; }
		public Guid StaffId { get; set; }
		public Staff Staff { get; set; }
	}
}
