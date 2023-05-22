using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffWorkRecords
{
	public class GetStaffWorkRecords : IRequest<StaffWorkRecordsDTO>
	{
		public Guid StaffId { get; set; }
	}
}
