using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItem
{
	public class UpdateItemHandler : RequestHandlerBase, IRequestHandler<UpdateItem>
	{
		public UpdateItemHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task Handle(UpdateItem request, CancellationToken cancellationToken)
		{
			var item = await _itemsRepository.GetById(request.UpdateItemDTO.Id, cancellationToken);
			if (item != null)
			{
				item.Price = request.UpdateItemDTO.Price;
				item.RequiredQuantity = request.UpdateItemDTO.RequiredQuantity;
				item.Quantity = request.UpdateItemDTO.Quantity;
				item.Name = request.UpdateItemDTO.Name;

				await _itemsRepository.Update(item, cancellationToken);
				await _itemsRepository.SaveChanges(cancellationToken);
			}
		}
	}
}