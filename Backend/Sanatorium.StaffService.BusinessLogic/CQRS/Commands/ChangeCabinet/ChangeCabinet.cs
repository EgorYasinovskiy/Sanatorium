using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeCabinet
{
	public class ChangeCabinet : IRequest
	{
		public Guid StaffId { get; set; }
		public int NewCabinet { get; set; }
	}
}
