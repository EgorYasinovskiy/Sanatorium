using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoomMove
{
	public class UpdateRoomMoveHandler : RequestHandlerBase, IRequestHandler<UpdateRoomMove>
	{
		public UpdateRoomMoveHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(UpdateRoomMove request, CancellationToken cancellationToken)
		{
			var roomMove = await _roomMoveRepository.GetById(request.UpdateRoomMoveDTO.Id, cancellationToken);
			if (roomMove == null)
				return;
			roomMove.MoveType = request.UpdateRoomMoveDTO.MoveType;
			roomMove.NewRoomId = request.UpdateRoomMoveDTO.NewRoomId;
			roomMove.OldRoomId = request.UpdateRoomMoveDTO.OldRoomId;
			roomMove.PatientId = request.UpdateRoomMoveDTO.PatientId;
			roomMove.Date = request.UpdateRoomMoveDTO.Date;
			await _roomMoveRepository.Update(roomMove, cancellationToken);
			await _roomMoveRepository.SaveChanges(cancellationToken);
		}
	}
}
