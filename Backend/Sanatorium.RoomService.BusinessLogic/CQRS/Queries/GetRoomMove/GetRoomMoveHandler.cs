using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMove
{
	public class GetRoomMoveHandler : RequestHandlerBase, IRequestHandler<GetRoomMove, RoomMoveDTO>
	{
		public GetRoomMoveHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomMoveDTO> Handle(GetRoomMove request, CancellationToken cancellationToken)
		{
			var rm = await _roomMoveRepository.GetById(request.Id, cancellationToken);
			return _mapper.Map<RoomMoveDTO>(rm);
		}
	}
}
