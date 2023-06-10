using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.BusinessLogic.CQRS.Queries.GetPatientInvoice
{
	internal class GetPatientInvoiceHandler : RequestHandlerBase, IRequestHandler<GetPatientInvoice, InvoiceDTO>
	{
		public GetPatientInvoiceHandler(IInvoiceRepository invoiceRepository, IInovoiceItemRepository invoiceItemRepository) : base(invoiceRepository, invoiceItemRepository)
		{
		}

		public Task<InvoiceDTO> Handle(GetPatientInvoice request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
