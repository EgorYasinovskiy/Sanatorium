using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffById
{
	public class GetStaffById : IRequest<StaffDTO>
	{
		public Guid StaffId { get; set; }
	}
}
