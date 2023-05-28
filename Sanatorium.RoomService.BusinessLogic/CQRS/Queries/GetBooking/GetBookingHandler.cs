using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBooking
{
	public class GetBookingHandler : RequestHandlerBase, IRequestHandler<GetBooking, BookingDTO>
	{
		public GetBookingHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<BookingDTO> Handle(GetBooking request, CancellationToken cancellationToken)
		{
			var booking = await _bookingRepository.GetById(request.Id, cancellationToken);
			return _mapper.Map<BookingDTO>(booking);
		}
	}
}
