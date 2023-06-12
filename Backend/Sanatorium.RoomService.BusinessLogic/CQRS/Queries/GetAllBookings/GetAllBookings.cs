using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllBookings
{
	public class GetAllBookings : IRequest<BookingList>
	{
	}
}
