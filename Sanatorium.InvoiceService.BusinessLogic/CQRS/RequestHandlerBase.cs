using AutoMapper;

using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected readonly IInvoiceRepository _invoiceRepository;
		protected readonly IInovoiceItemRepository _invoiceItemRepository;
		protected readonly IRoomServiceChannel _roomServiceChannel;
		protected readonly IMedicalRecordServiceChannel _medicalRecordServiceChannel;
		protected readonly IStaffServiceChannel _staffServiceChannel;
		protected readonly IInventoryServiceChannel _inventoryServiceChannel;
		protected readonly IMapper _mapper;

		public RequestHandlerBase(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository, IRoomServiceChannel roomServiceChannel, IMedicalRecordServiceChannel medicalRecordServiceChannel, IMapper mapper, IInventoryServiceChannel inventoryServiceChannel, IStaffServiceChannel staffServiceChannel)
		{
			_invoiceRepository = invoiceRepository;
			_invoiceItemRepository = invoiceItemRepository;
			_roomServiceChannel = roomServiceChannel;
			_medicalRecordServiceChannel = medicalRecordServiceChannel;
			_mapper = mapper;
			_inventoryServiceChannel = inventoryServiceChannel;
			_staffServiceChannel = staffServiceChannel;
		}
	}
}
