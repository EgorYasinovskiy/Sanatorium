using AutoMapper;

using MediatR;

using Sanatorium.InventoryService.BusinessLogic.Interfaces;

namespace Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItemRecord
{
	public class UpdateItemRecordHandler : RequestHandlerBase, IRequestHandler<UpdateItemRecord>
	{
		public UpdateItemRecordHandler(IItemsRepository itemsRepository, IRecordsRepository recordsRepository, IMapper mapper) : base(itemsRepository, recordsRepository, mapper)
		{
		}

		public async Task Handle(UpdateItemRecord request, CancellationToken cancellationToken)
		{
			var record = await _recordsRepository.GetById(request.UpdateRecordDTO.Id, cancellationToken);
			if (record == null)
				return;
			// Откат изменений переданных в прошлый раз
			var oldItem = await _itemsRepository.GetById(record.Id, cancellationToken);
			if (oldItem == null) return;
			var newItem = record.ItemId == request.UpdateRecordDTO.ItemId ? oldItem : await _itemsRepository.GetById(request.UpdateRecordDTO.ItemId, cancellationToken);
			if (newItem == null) return;

			var change = record.RecordType == Model.RecordType.Sending ? record.Quantity : -record.Quantity;
			oldItem.Quantity += change;

			change = request.UpdateRecordDTO.RecordType == Model.RecordType.Sending ? -request.UpdateRecordDTO.Quantity : request.UpdateRecordDTO.Quantity;
			record.Quantity = request.UpdateRecordDTO.Quantity;
			record.DateTime = request.UpdateRecordDTO.DateTime;
			record.RecordType = request.UpdateRecordDTO.RecordType;
			await _recordsRepository.Update(record, cancellationToken);

			if (oldItem.Id == newItem.Id)
			{
				oldItem.Quantity += change;
				await _itemsRepository.Update(oldItem, cancellationToken);
			}
			else
			{
				newItem.Quantity += change;
				await _itemsRepository.Update(newItem, cancellationToken);
				await _itemsRepository.Update(oldItem, cancellationToken);
			}
			await _recordsRepository.SaveChanges(cancellationToken);
			await _itemsRepository.SaveChanges(cancellationToken);
		}
	}
}
