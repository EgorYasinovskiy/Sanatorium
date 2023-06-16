using AutoMapper;

using MediatR;

using Sanatorium.Common;
using Sanatorium.Common.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoiceHandler : RequestHandlerBase, IRequestHandler<GetInvoice, InvoiceDTO>
	{
		public GetInvoiceHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InvoiceDTO> Handle(GetInvoice request, CancellationToken cancellationToken)
		{
			var missing = await _itemsRepository.GetMissing(cancellationToken);
			var invoiceItems = new List<InvoiceItemDTO>();
			foreach (var item in missing)
			{
				invoiceItems.Add(new InvoiceItemDTO()
				{
					Name = item.Name,
					Price = item.Price,
					Quanitity = item.RequiredQuantity - item.Quantity
				});
			};
			try
			{
				return new InvoiceDTO()
				{
					ParentId = new Guid(Constants.InventoryInvoiceGuid),
					DateFrom = DateOnly.FromDateTime(DateTime.Now),
					Items = invoiceItems,
				};
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
