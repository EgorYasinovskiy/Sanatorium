using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.DTO;
using Sanatorium.InventoryService.BusinessLogic.Interfaces;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItemRecord
{
	public class AddItemRecordHandler : RequestHandlerBase, IRequestHandler<AddItemRecord, InventoryRecordDTO>
	{
		public AddItemRecordHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task<InventoryRecordDTO> Handle(AddItemRecord request, CancellationToken cancellationToken)
		{
			var record = new InventoryHistoryRecord()
			{
				DateTime = request.CreateRecordDTO.DateTime,
				Id = Guid.NewGuid(),
				ItemId = request.CreateRecordDTO.ItemId,
				Quantity = request.CreateRecordDTO.Quantity,
				RecordType = request.CreateRecordDTO.RecordType
			};

			var item = await _itemsRepository.GetById(request.CreateRecordDTO.ItemId, cancellationToken);
			var change = record.RecordType == RecordType.Sending ? -record.Quantity : record.Quantity;
			item.Quantity += change;
			await _recordsRepository.Create(record, cancellationToken);
			await _itemsRepository.Update(item, cancellationToken);
			record.Item = item;
			await _recordsRepository.SaveChanges(cancellationToken);
			await _itemsRepository.SaveChanges(cancellationToken);
			return _mapper.Map<InventoryRecordDTO>(record);
		}
	}
}
