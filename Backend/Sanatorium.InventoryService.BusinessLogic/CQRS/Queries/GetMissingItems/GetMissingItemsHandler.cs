using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetMissingItems
{
	public class GetMissingItemsHandler : RequestHandlerBase, IRequestHandler<GetMissingItems, InventoryItemListDTO>
	{
		public GetMissingItemsHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryItemListDTO> Handle(GetMissingItems request, CancellationToken cancellationToken)
		{
			var items = await _itemsRepository.GetMissing(cancellationToken);
			if (items.Any())
				return null;

			var result = new InventoryItemListDTO()
			{
				Items = _mapper.Map<IEnumerable<InventoryItemDTO>>(items)
			};
			return result;
		}
	}
}
