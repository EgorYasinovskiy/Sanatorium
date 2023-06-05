using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetItemById
{
	public class GetItemByIdHandler : RequestHandlerBase, IRequestHandler<GetItemById, InventoryItemDTO>
	{
		public GetItemByIdHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryItemDTO> Handle(GetItemById request, CancellationToken cancellationToken)
		{
			return _mapper.Map<InventoryItemDTO>( await _itemsRepository.GetById(request.Id, cancellationToken));
		}
	}
}
