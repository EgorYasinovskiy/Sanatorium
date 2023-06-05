using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByDateRange
{
	public class GetRecordsByDateRangeHandler : RequestHandlerBase, IRequestHandler<GetRecordsByDateRange, InventoryRecordListDTO
	{
		public GetRecordsByDateRangeHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{

		}

		async Task<InventoryRecordListDTO> IRequestHandler<GetRecordsByDateRange, InventoryRecordListDTO>.Handle(GetRecordsByDateRange request, CancellationToken cancellationToken)
		{
			var records = await _recordsRepository.GetByDateRange(request.From, request.To, cancellationToken);
			if (records == null || !records.Any())
				return null;
			return new InventoryRecordListDTO()
			{
				InventoryRecords = _mapper.Map<IEnumerable<InventoryRecordDTO>>(records);
			}
		}
	}


}
