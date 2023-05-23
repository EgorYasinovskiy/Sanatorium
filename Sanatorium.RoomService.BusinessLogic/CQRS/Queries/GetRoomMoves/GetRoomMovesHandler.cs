using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMoves
{
	public class GetRoomMovesHandler : RequestHandlerBase, IRequestHandler<GetRoomMoves, RoomMoveList>
	{
		public GetRoomMovesHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomMoveList> Handle(GetRoomMoves request, CancellationToken cancellationToken)
		{
			var roomMovesTask = _roomMoveRepository.GetByPatientId(request.PatientId, cancellationToken);
			var roomMoves = (await roomMovesTask).Where(x => x.Date >= request.PeriodStart && x.Date <= request.PeriodEnd);
			var result = new RoomMoveList()
			{
				RoomMoves = _mapper.Map<IEnumerable<RoomMoveDTO>>(roomMoves)
			};
			return result;
		}
	}
}
