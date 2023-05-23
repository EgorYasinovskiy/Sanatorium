using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateBooking
{
	public class CreateBooking : IRequest<BookingDTO>
	{
		public CreateBookingDTO CreateBookingDTO { get; set; }
	}
}
