using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoomMove
{
	public class DeleteRoomMoveHandler : RequestHandlerBase, IRequestHandler<DeleteRoomMove>
	{
		public DeleteRoomMoveHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(DeleteRoomMove request, CancellationToken cancellationToken)
		{
			await _roomMoveRepository.DeleteById(request.Id, cancellationToken);
			await _roomMoveRepository.SaveChanges(cancellationToken);
		}
	}
}
