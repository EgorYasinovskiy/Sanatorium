using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItem
{
	public class DeleteItemHandler : RequestHandlerBase, IRequestHandler<DeleteItem>
	{
		public DeleteItemHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task Handle(DeleteItem request, CancellationToken cancellationToken)
		{
			await _itemsRepository.DeleteById(request.Id, cancellationToken);
		}
	}
}
