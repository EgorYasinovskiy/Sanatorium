using AutoMapper;

using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreatePatientInvoice
{
	public class GetOrCreatePatientInvoiceHandler : RequestHandlerBase, IRequestHandler<GetOrCreatePatientInvoice, InvoiceDTO>
	{
		public GetOrCreatePatientInvoiceHandler(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository, IRoomServiceChannel roomServiceChannel, IMedicalRecordServiceChannel medicalRecordServiceChannel, IMapper mapper, IInventoryServiceChannel inventoryServiceChannel, IStaffServiceChannel staffServiceChannel) : base(invoiceRepository, invoiceItemRepository, roomServiceChannel, medicalRecordServiceChannel, mapper, inventoryServiceChannel, staffServiceChannel)
		{
		}

		public async Task<InvoiceDTO> Handle(GetOrCreatePatientInvoice request, CancellationToken cancellationToken)
		{
			var res = await _invoiceRepository.GetInfoiceByParentIdAndDate(request.PatientId, request.DateFrom, cancellationToken);
			if (!request.RefreshData)
			{
				if (res != null)
					return _mapper.Map<InvoiceDTO>(res);
			}
			var roomInvoice = await _roomServiceChannel.GetInvoice(request.PatientId, request.DateFrom, cancellationToken);
			var medicalInvoice = await _medicalRecordServiceChannel.GetInvoice(request.PatientId, request.DateFrom, cancellationToken);

			var allItems = roomInvoice.Items.Union(medicalInvoice.Items);
			var invoiceGuid = res.Id == Guid.Empty ? Guid.NewGuid() : res.Id;
			Parallel.ForEach(allItems, (item) => item.InvoiceId = invoiceGuid);
			var invoiceDTO = new InvoiceDTO()
			{
				ParentId = request.PatientId,
				DateFrom = request.DateFrom,
				Payed = false,
				Id = invoiceGuid,
				Items = allItems
			};
			var invoice = _mapper.Map<Invoice>(invoiceDTO);
			if (res != null)
				await _invoiceRepository.Update(invoice, cancellationToken);
			else
				await _invoiceRepository.Create(invoice, cancellationToken);

			await _invoiceItemRepository.SaveChanges(cancellationToken);
			return invoiceDTO;
		}
	}
}
