using AutoMapper;

using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateStaffInvoice
{
	public class GetOrCreateStaffInvoiceHandler : RequestHandlerBase, IRequestHandler<GetOrCreateStaffInvoice, InvoiceDTO>
	{
		public GetOrCreateStaffInvoiceHandler(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository, IRoomServiceChannel roomServiceChannel, IMedicalRecordServiceChannel medicalRecordServiceChannel, IMapper mapper, IInventoryServiceChannel inventoryServiceChannel, IStaffServiceChannel staffServiceChannel) : base(invoiceRepository, invoiceItemRepository, roomServiceChannel, medicalRecordServiceChannel, mapper, inventoryServiceChannel, staffServiceChannel)
		{
		}

		public async Task<InvoiceDTO> Handle(GetOrCreateStaffInvoice request, CancellationToken cancellationToken)
		{
			var invoice = await _invoiceRepository.GetInfoiceByParentIdAndDate(request.StaffId, request.DateFrom, cancellationToken);
			if(invoice != null)
				return _mapper.Map<InvoiceDTO>(invoice);
			var result = await _staffServiceChannel.GetStaffInvoice(request.StaffId, request.DateFrom, cancellationToken);
			if (result == null || result.Items == null || !result.Items.Any())
				return null;

			result.Id = Guid.NewGuid();
			result.DateFrom = request.DateFrom;
			result.ParentId = request.StaffId;
			invoice = _mapper.Map<Invoice>(result);

			await _invoiceRepository.Create(invoice,cancellationToken);
			await _invoiceRepository.SaveChanges(cancellationToken);
			return result;

		}
	}
}
