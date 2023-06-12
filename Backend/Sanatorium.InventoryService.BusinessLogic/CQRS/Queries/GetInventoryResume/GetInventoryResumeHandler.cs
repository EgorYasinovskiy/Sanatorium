using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryResume
{
	public class GetInventoryResumeHandler : RequestHandlerBase, IRequestHandler<GetInventoryResume, InventoryResumeDTO>
	{
		public GetInventoryResumeHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryResumeDTO> Handle(GetInventoryResume request, CancellationToken cancellationToken)
		{
			var items = await _itemsRepository.GetAll(cancellationToken);
			return new InventoryResumeDTO()
			{
				Items = _mapper.Map<IEnumerable<InventoryItemShortDTO>>(items)
			};
		}
	}
}
