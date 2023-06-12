using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoom
{
	public class GetRoomHandler : RequestHandlerBase, IRequestHandler<GetRoom, RoomDTO>
	{
		public GetRoomHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomDTO> Handle(GetRoom request, CancellationToken cancellationToken)
		{
			var room = await _roomRepository.GetById(request.Id, cancellationToken);
			return room == null ? null : _mapper.Map<RoomDTO>(room);
		}
	}
}
