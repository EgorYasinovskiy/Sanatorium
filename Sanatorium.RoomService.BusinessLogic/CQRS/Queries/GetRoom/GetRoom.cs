using MediatR;

using Sanatorium.RoomService.BusinessLogic.DTO;
namespace Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoom
{
	public class GetRoom : IRequest<RoomDTO>
	{
		public Guid Id { get; set; }
	}
}
