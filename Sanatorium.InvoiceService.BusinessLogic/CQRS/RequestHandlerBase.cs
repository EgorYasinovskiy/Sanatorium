using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected readonly IInvoiceRepository _invoiceRepository;
		protected readonly IInovoiceItemRepository _invoiceItemRepository;
		protected readonly IRoomServiceChannel _roomServiceChannel;
		protected readonly IMedicalRecordServiceChannel _medicalRecordServiceChannel;

		public RequestHandlerBase(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository, IRoomServiceChannel roomServiceChannel, IMedicalRecordServiceChannel medicalRecordServiceChannel)
		{
			_invoiceRepository = invoiceRepository;
			_invoiceItemRepository = invoiceItemRepository;
			_roomServiceChannel = roomServiceChannel;
			_medicalRecordServiceChannel = medicalRecordServiceChannel;
		}
	}
}
