using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateBooking
{
	public class CreateBookingHandler : RequestHandlerBase, IRequestHandler<CreateBooking, BookingDTO>
	{
		public CreateBookingHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<BookingDTO> Handle(CreateBooking request, CancellationToken cancellationToken)
		{
			var newBooking = new Booking()
			{
				Id = Guid.NewGuid(),
				RoomId = request.CreateBookingDTO.RoomId,
				ArrivalDate = request.CreateBookingDTO.ArrivalDate,
				DurationInDays = request.CreateBookingDTO.DurationInDays
			};
			await _bookingRepository.Create(newBooking, cancellationToken);
			await _bookingRepository.SaveChanges(cancellationToken);

			return _mapper.Map<BookingDTO>(newBooking);
		}
	}
}
