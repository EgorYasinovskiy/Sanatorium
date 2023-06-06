using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByItem
{
	public class GetRecordsByItemHandler : RequestHandlerBase, IRequestHandler<GetRecordsByItem, InventoryRecordListDTO>
	{
		public GetRecordsByItemHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryRecordListDTO> Handle(GetRecordsByItem request, CancellationToken cancellationToken)
		{
			var records = await _recordsRepository.GetByItem(request.ItemId, cancellationToken);
			if (records != null || !records.Any())
				return null;
			return new InventoryRecordListDTO
			{
				InventoryRecords = _mapper.Map<IEnumerable<InventoryRecordDTO>>(records)
			};
	}
	}
}
