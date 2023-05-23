using MediatR;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteBooking
{
	public class DeleteBooking : IRequest
	{
		public Guid Id { get; set; }
	}
}
