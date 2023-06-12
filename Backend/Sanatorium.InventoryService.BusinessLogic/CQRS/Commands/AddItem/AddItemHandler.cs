using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItem
{
	public class AddItemHandler : RequestHandlerBase, IRequestHandler<AddItem, InventoryItemDTO>
	{
		public AddItemHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryItemDTO> Handle(AddItem request, CancellationToken cancellationToken)
		{
			var item = new InventoryItem()
			{
				Id = Guid.NewGuid(),
				Name = request.CreateItemDTO.Name,
				Price = request.CreateItemDTO.Price,
				Quantity = request.CreateItemDTO.Quantity,
				RequiredQuantity = request.CreateItemDTO.RequiredQuantity
			};
			await _itemsRepository.Create(item, cancellationToken);
			await _itemsRepository.SaveChanges(cancellationToken);

			return _mapper.Map<InventoryItemDTO>(item);
		}
	}
}
