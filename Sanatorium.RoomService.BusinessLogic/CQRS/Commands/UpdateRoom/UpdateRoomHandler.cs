using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoom
{
	public class UpdateRoomHandler : RequestHandlerBase, IRequestHandler<UpdateRoom>
	{
		public UpdateRoomHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task Handle(UpdateRoom request, CancellationToken cancellationToken)
		{
			var room = await _roomRepository.GetById(request.UpdateRoomDTO.Id,cancellationToken);
			if (room == null)
				return;
			room.Category = request.UpdateRoomDTO.Category;
			room.CostPerDay = request.UpdateRoomDTO.CostPerDay;
			room.RoomNumber = request.UpdateRoomDTO.RoomNumber;
			room.IsFree = request.UpdateRoomDTO.IsFree;
			room.BedsCount = request.UpdateRoomDTO.BedsCount;
			await _roomRepository.Update(room, cancellationToken);
			await _roomRepository.SaveChanges(cancellationToken);
		}
	}
}
