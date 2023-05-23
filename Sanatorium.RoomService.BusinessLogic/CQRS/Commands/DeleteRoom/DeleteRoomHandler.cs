using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoom
{
	public class DeleteRoomHandler : RequestHandlerBase, IRequestHandler<DeleteRoom>
	{
		public DeleteRoomHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(DeleteRoom request, CancellationToken cancellationToken)
		{
			await _roomRepository.DeleteById(request.Id, cancellationToken);
			await _roomRepository.SaveChanges(cancellationToken);
		}
	}
}
