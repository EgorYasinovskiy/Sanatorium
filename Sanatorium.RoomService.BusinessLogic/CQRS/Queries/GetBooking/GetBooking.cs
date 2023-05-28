using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBooking
{
	public class GetBooking : IRequest<BookingDTO>
	{
		public Guid Id { get; set; }
	}
}
