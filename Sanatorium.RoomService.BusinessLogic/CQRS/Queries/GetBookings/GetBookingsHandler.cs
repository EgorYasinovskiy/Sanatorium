using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBookings
{
	public class GetBookingsHandler : RequestHandlerBase, IRequestHandler<GetBookings, BookingList>
	{
		public GetBookingsHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<BookingList> Handle(GetBookings request, CancellationToken cancellationToken)
		{
			var bookings = await _bookingRepository.GetActual(cancellationToken);
			var result = new BookingList()
			{
				Bookings = _mapper.Map<IEnumerable<BookingDTO>>(bookings)
			};
			return result;
		}
	}
}
