using AutoMapper;

using MediatR;

using Sanatorium.Common;
using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateInventoryInvoice
{
	public class GetOrCreateInventoryInvoiceHandler : RequestHandlerBase, IRequestHandler<GetOrCreateInventoryInvoice, InvoiceDTO>
	{
		public GetOrCreateInventoryInvoiceHandler(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository, IRoomServiceChannel roomServiceChannel, IMedicalRecordServiceChannel medicalRecordServiceChannel, IMapper mapper, IInventoryServiceChannel inventoryServiceChannel, IStaffServiceChannel staffServiceChannel) : base(invoiceRepository, invoiceItemRepository, roomServiceChannel, medicalRecordServiceChannel, mapper, inventoryServiceChannel, staffServiceChannel)
		{
		}

		public async Task<InvoiceDTO> Handle(GetOrCreateInventoryInvoice request, CancellationToken cancellationToken)
		{
			var invoice = await _invoiceRepository.GetInfoiceByParentIdAndDate(new Guid(Constants.InventoryInvoiceGuid), request.DateFrom, cancellationToken);
			if (invoice != null)
				return _mapper.Map<InvoiceDTO>(invoice);

			var result = await _inventoryServiceChannel.GetInvoice(cancellationToken);
			if (result == null || result.Items == null || !result.Items.Any())
				return null;

			result.ParentId = new Guid(Constants.InventoryInvoiceGuid);
			result.DateFrom = request.DateFrom;
			result.Id = Guid.NewGuid();

			invoice = _mapper.Map<Invoice>(result);
			await _invoiceRepository.Create(invoice, cancellationToken);
			await _invoiceRepository.SaveChanges(cancellationToken);
			return result;
		}
	}
}