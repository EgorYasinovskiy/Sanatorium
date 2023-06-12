using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItemRecord
{
	public class DeleteItemRecordHandler : RequestHandlerBase, IRequestHandler<DeleteItemRecord>
	{
		public DeleteItemRecordHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task Handle(DeleteItemRecord request, CancellationToken cancellationToken)
		{
			await _recordsRepository.DeleteById(request.Id, cancellationToken);
		}
	}
}
