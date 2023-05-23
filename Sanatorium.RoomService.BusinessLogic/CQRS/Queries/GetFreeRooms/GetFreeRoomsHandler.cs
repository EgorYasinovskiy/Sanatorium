using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetFreeRooms
{
	public class GetFreeRoomsHandler : RequestHandlerBase, IRequestHandler<GetFreeRooms, RoomListDTO>
	{
		public GetFreeRoomsHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomListDTO> Handle(GetFreeRooms request, CancellationToken cancellationToken)
		{
			var rooms = await _roomRepository.GetFree(cancellationToken);
			var result = new RoomListDTO()
			{
				Rooms = _mapper.Map<IEnumerable<RoomDTO>>(rooms)
			};
			return result;
		}
	}
}
