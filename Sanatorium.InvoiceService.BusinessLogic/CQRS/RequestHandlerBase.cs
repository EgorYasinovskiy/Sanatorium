using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		IInvoiceRepository _invoiceRepository;
		IInovoiceItemRepository _invoiceItemRepository;

		public RequestHandlerBase(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository)
		{
			_invoiceRepository = invoiceRepository;
			_invoiceItemRepository = invoiceItemRepository;
		}
	}
}
