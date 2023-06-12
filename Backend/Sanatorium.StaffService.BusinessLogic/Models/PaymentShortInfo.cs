namespace Sanatorium.StaffService.BusinessLogic.Models
{
	public class PaymentShortInfo
	{
		public DateOnly PeriodStart { get; set; }
		public DateOnly PeriodEnd { get; set; }
		public PaymentShortInfoItem[] Payments { get; set; }
	}
}