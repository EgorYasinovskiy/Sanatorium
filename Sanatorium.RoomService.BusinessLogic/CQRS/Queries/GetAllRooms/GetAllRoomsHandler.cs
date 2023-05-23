using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllRooms
{
	public class GetAllRoomsHandler : RequestHandlerBase, IRequestHandler<GetAllRooms, RoomListDTO>
	{
		public GetAllRoomsHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomListDTO> Handle(GetAllRooms request, CancellationToken cancellationToken)
		{
			var rooms = await _roomRepository.GetAll(cancellationToken);
			var result = new RoomListDTO()
			{
				Rooms = _mapper.Map<IEnumerable<RoomDTO>>(rooms)
			};
			return result;
		}
	}
}
