using AutoMapper;

using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffInvoice
{
	internal class GetStaffInvoiceHandler : RequestHandlerBase, IRequestHandler<GetStaffInvoice, InvoiceDTO>
	{
		public GetStaffInvoiceHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<InvoiceDTO> Handle(GetStaffInvoice request, CancellationToken cancellationToken)
		{
			var records = await _workRecordRepository.GetWithCustomFilter(x => x.StaffId == request.StaffId && x.Date >= request.DateFrom, cancellationToken);
			if (!records.Any())
				return null;

			var invoiceItems = records.Select(x =>
			{
				return new InvoiceItemDTO()
				{
					Name = $"Рабочий день {x.Date}",
					Price = x.Staff.SalaryPerHour,
					Quanitity = (int)x.Hours
				};
			});
			
			return new InvoiceDTO()
			{
				DateFrom = request.DateFrom,
				Items = invoiceItems,
				ParentId = request.StaffId
			};
		}
	}
}
