using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateBooking
{
	public class UpdateBookingHandler : RequestHandlerBase, IRequestHandler<UpdateBooking>
	{
		public UpdateBookingHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(UpdateBooking request, CancellationToken cancellationToken)
		{
			var booking = await _bookingRepository.GetById(request.UpdateBookingDTO.Id,cancellationToken);
			if (booking == null)
				return;

			booking.DurationInDays = request.UpdateBookingDTO.DurationInDays;
			booking.ArrivalDate = request.UpdateBookingDTO.ArrivalDate;
			booking.RoomId = request.UpdateBookingDTO.RoomId;
			await _bookingRepository.Update(booking,cancellationToken);
			await _bookingRepository.SaveChanges(cancellationToken);
		}
	}
}
