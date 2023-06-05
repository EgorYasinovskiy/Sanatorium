using AutoMapper;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected IItemsRepository _itemsRepository;
		protected IRecordsRepository _recordsRepository;
		protected IMapper _mapper;

		public RequestHandlerBase(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper)
		{
			_itemsRepository = itemsRepository;
			_recordsRepository = recordsRepository;
			_mapper = mapper;
		}
	}
}
