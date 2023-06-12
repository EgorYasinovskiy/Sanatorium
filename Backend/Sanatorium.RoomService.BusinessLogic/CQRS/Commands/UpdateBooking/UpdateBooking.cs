using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateBooking
{
	public class UpdateBooking : IRequest
	{
		public UpdateBookingDTO UpdateBookingDTO { get; set; }
	}
}
