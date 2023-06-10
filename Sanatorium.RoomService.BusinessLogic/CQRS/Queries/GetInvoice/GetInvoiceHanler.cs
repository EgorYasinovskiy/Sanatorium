using AutoMapper;

using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoiceHanler : RequestHandlerBase, IRequestHandler<GetInvoice, InvoiceDTO>
	{
		public GetInvoiceHanler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<InvoiceDTO> Handle(GetInvoice request, CancellationToken cancellationToken)
		{
			var moves = (await _roomMoveRepository.GetByPatientId(request.PatientID, cancellationToken)).Where(x => x.Date >= request.From);
			// Пары заселение выселение, для подсчета дней в каждом номере и соотвественно суммы
			var movesPairs = new Dictionary<RoomMove, RoomMove>();
			foreach (var move in moves)
			{
				if (move.MoveType != RoomMoveType.Settlement)
					continue;
				movesPairs.Add(move, moves.FirstOrDefault(x => x.MoveType == RoomMoveType.Eviction && x.Date >= move.Date && x.RoomId == move.RoomId));
			}
			var zeroTime = new TimeOnly(0);
			var invoiceItems = new List<InvoiceItemDTO>();
			foreach (var pair in movesPairs)
			{
				invoiceItems.Add(new InvoiceItemDTO()
				{
					Quanitity = (pair.Value.Date.ToDateTime(zeroTime) - pair.Key.Date.ToDateTime(zeroTime)).Days,
					Price = pair.Key.Room.CostPerDay,
					Name = $"Комната №{pair.Key.Room.RoomNumber}. {pair.Key.Room.Category} категория"
				});
			}

			return new InvoiceDTO()
			{
				Items = invoiceItems
			};
		}
	}
}
