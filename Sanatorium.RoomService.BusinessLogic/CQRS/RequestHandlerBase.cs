using AutoMapper;

using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.BusinessLogic.CQRS
{
	public class RequestHandlerBase
	{
		protected IRoomRepository _roomRepository;
		protected IRoomMoveRepository _roomMoveRepository;
		protected IBookingRepository _bookingRepository;
		protected IMapper _mapper;

		public RequestHandlerBase(IRoomRepository roomRepository, IRoomMoveRepository roomMoveRepository, IBookingRepository bookingRepository, IMapper mapper)
		{
			_roomRepository = roomRepository;
			_roomMoveRepository = roomMoveRepository;
			_bookingRepository = bookingRepository;
			_mapper = mapper;
		}
	}
}
