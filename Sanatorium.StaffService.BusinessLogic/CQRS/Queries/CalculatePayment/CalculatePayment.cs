using MediatR;

using Sanatorium.StaffService.BusinessLogic.Models;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.CalculatePayment
{
    public class CalculatePayment : IRequest<PaymentInfo>
    {
        public DateOnly PeriodStart { get; set; }
        public DateOnly PeriodEnd { get; set; }
        public Guid StaffId { get; set; }
    }
}
