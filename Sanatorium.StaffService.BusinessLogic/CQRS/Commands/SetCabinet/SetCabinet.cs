using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.SetCabinet
{
	public class SetCabinet : IRequest
	{
		public Guid StaffId { get; set; }
		public int NewCabinet { get; set; }
	}
}
