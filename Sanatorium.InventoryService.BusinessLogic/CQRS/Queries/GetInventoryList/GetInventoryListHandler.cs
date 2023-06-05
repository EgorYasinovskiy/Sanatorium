using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryList
{
	public class GetInventoryListHandler : RequestHandlerBase, IRequestHandler<GetInventoryList, InventoryItemListDTO>
	{
		public GetInventoryListHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryItemListDTO> Handle(GetInventoryList request, CancellationToken cancellationToken)
		{
			var items = await _itemsRepository.GetAll(cancellationToken);
			return new InventoryItemListDTO()
			{
				Items = _mapper.Map<IEnumerable<InventoryItemDTO>>(items)
			};
		}
	}
}
