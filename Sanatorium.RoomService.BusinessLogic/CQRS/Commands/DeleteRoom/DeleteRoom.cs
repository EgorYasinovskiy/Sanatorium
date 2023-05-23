using MediatR;

namespace Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoom
{
	public class DeleteRoom : IRequest
	{
		public Guid Id { get; set; }
	}
}
