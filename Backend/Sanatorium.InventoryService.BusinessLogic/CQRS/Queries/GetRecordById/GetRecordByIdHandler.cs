using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordById
{
	public class GetRecordByIdHandler : RequestHandlerBase, IRequestHandler<GetRecordById, InventoryRecordDTO>
	{
		public GetRecordByIdHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryRecordDTO> Handle(GetRecordById request, CancellationToken cancellationToken)
		{
			var result = await _recordsRepository.GetById(request.Id, cancellationToken);
			return result == null ? null : _mapper.Map<InventoryRecordDTO>(result);
		}
	}
}
