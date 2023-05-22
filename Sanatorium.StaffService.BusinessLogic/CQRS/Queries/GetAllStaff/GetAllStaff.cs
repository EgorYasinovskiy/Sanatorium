using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetAllStaff
{
	public class GetAllStaff : IRequest<StaffList>
	{
	}
}
