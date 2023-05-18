namespace Sanatorium.StaffService.BusinessLogic.Models
{
	public class PaymentInfo
	{
		public string StaffName { get; set; }
		public string Period => $"{PaymentInfoByDate.Keys.Min()} - {PaymentInfoByDate.Keys.Max()}";
		public double Sum => PaymentInfoByDate.Sum(x => x.Value.Salary);
		public Dictionary<DateOnly, PaymentInfoItem> PaymentInfoByDate { get; set; }
	}
}
