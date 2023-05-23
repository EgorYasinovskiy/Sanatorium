using AutoMapper;

using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoom
{
	public class CreateRoomHandler : RequestHandlerBase, IRequestHandler<CreateRoom, RoomDTO>
	{
		public CreateRoomHandler(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper) : base(roomRepository, roomMoveRepository, bookingRepository, mapper)
		{
		}

		public async Task<RoomDTO> Handle(CreateRoom request, CancellationToken cancellationToken)
		{
			var newRoom = new Room()
			{
				BedsCount = request.CreateRoomDTO.BedsCount,
				Category = request.CreateRoomDTO.Category,
				CostPerDay = request.CreateRoomDTO.CostPerDay,
				IsFree = true,
				RoomNumber = request.CreateRoomDTO.RoomNumber,
				Id = Guid.NewGuid()
			};
			await _roomRepository.Create(newRoom, cancellationToken);
			await _roomRepository.SaveChanges(cancellationToken);
			return _mapper.Map<RoomDTO>(newRoom);
		}
	}
}
