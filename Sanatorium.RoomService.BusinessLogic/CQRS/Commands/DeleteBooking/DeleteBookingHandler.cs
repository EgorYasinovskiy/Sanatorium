using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteBooking
{
	public class DeleteBookingHandler : RequestHandlerBase, IRequestHandler<DeleteBooking>
	{
		public DeleteBookingHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(DeleteBooking request, CancellationToken cancellationToken)
		{
			await _bookingRepository.DeleteById(request.Id, cancellationToken);
			await _bookingRepository.SaveChanges(cancellationToken);
		}
	}
}
