using MediatR;

using Sanatorium.StaffService.BusinessLogic.Models;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.CalculatePaymentsForAll
{
	public class CalculatePaymentsForAll : IRequest<PaymentShortInfo>
	{
		public DateOnly PeriodStart { get; set; }
		public DateOnly PeriodEnd { get; set; }
	}
}
