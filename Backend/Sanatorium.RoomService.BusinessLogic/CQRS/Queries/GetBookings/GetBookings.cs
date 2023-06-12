using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBookings
{
	public class GetBookings : IRequest<BookingList>
	{
	}
}
