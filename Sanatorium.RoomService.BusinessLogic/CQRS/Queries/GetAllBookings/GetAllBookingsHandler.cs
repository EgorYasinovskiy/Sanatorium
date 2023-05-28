using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllBookings
{
	public class GetAllBookingsHandler : RequestHandlerBase, IRequestHandler<GetAllBookings, BookingList>
	{
		public GetAllBookingsHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<BookingList> Handle(GetAllBookings request, CancellationToken cancellationToken)
		{
			var bookingList = await _bookingRepository.GetAll(cancellationToken);
			return _mapper.Map<BookingList>(bookingList);
		}
	}
}
