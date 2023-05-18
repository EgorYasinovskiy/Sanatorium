using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.BusinessLogic.Models;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.CalculatePayment
{
    public class CalculatePaymentHandler : RequestHandlerBase, IRequestHandler<CalculatePayment, PaymentInfo>
    {
        public CalculatePaymentHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
        {
        }

        public async Task<PaymentInfo> Handle(CalculatePayment request, CancellationToken cancellationToken)
        {
            var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
            var records = await _workRecordRepository.GetByStaffId(request.StaffId, cancellationToken);
            records = records.Where(x => x.Date >= request.PeriodStart && x.Date <= request.PeriodEnd);
            return new PaymentInfo
            {
                PaymentInfoByDate = records.ToDictionary(x => x.Date, x => new PaymentInfoItem()
                {
                    Hours = x.Hours,
                    Salary = x.Hours * staff.SalaryPerHour
                }),
                StaffName = staff.GetDisplayString()
            };

        }
    }
}
