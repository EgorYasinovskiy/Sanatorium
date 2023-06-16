using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMovesByPatient
{
	public class GetRoomMovesByPatientHandler : RequestHandlerBase, IRequestHandler<GetRoomMovesByPatient, RoomMoveList>
	{
		public GetRoomMovesByPatientHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomMoveList> Handle(GetRoomMovesByPatient request, CancellationToken cancellationToken)
		{
			var moves = await _roomMoveRepository.GetByPatientId(request.PatientId, cancellationToken);
			if (moves.Any())
			{
				return new RoomMoveList { RoomMoves = _mapper.Map<IEnumerable<RoomMoveDTO>>(moves) };
			}
			return null;
		}
	}
}
