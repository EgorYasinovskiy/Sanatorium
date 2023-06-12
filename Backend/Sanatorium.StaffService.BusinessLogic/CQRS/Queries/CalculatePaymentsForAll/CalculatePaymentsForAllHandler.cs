using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.BusinessLogic.Models;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.CalculatePaymentsForAll
{
	public class CalculatePaymentsForAllHandler : RequestHandlerBase, IRequestHandler<CalculatePaymentsForAll, PaymentShortInfo>
	{
		public CalculatePaymentsForAllHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<PaymentShortInfo> Handle(CalculatePaymentsForAll request, CancellationToken cancellationToken)
		{
			var workRecords = (await _workRecordRepository.GetAll(cancellationToken))
				.Where(x => x.Date >= request.PeriodStart && x.Date <= request.PeriodEnd)
				.GroupBy(x => x.StaffId)
				.Select(x =>
				{
					var staff = _staffRepository.GetById(x.Key, cancellationToken).GetAwaiter().GetResult();
					if (staff == null)
						return null;
					return new PaymentShortInfoItem()
					{
						StaffName = staff?.GetDisplayString(),
						Payment = x.Sum(x => x.Hours) * staff.SalaryPerHour
					};
				});
			return new PaymentShortInfo()
			{
				PeriodStart = request.PeriodStart,
				PeriodEnd = request.PeriodEnd,
				Payments = workRecords.Where(x => x != null).ToArray()
			};
		}
	}
}
