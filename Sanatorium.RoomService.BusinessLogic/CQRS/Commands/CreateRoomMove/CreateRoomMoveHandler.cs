using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoomMove
{
	public class CreateRoomMoveHandler : RequestHandlerBase, IRequestHandler<CreateRoomMove, RoomMoveDTO>
	{
		public CreateRoomMoveHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomMoveDTO> Handle(CreateRoomMove request, CancellationToken cancellationToken)
		{
			var newMove = new RoomMove()
			{
				Date = request.CreateRoomMoveDTO.Date,
				MoveType = request.CreateRoomMoveDTO.MoveType,
				NewRoomId = request.CreateRoomMoveDTO.NewRoomId,
				OldRoomId = request.CreateRoomMoveDTO.OldRoomId,
				PatientId = request.CreateRoomMoveDTO.PatientId,
				Id = Guid.NewGuid()
			};

			await _roomMoveRepository.Create(newMove, cancellationToken);
			await _roomMoveRepository.SaveChanges(cancellationToken);

			return newMove;
		}
	}
}
