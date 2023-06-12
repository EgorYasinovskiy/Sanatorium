using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.DeleteWorkTime
{
	public class DeleteWorktimeHandler : RequestHandlerBase, IRequestHandler<DeleteWorktime>
	{
		public DeleteWorktimeHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(DeleteWorktime request, CancellationToken cancellationToken)
		{
			await _workRecordRepository.DeleteById(request.RecordId, cancellationToken);
		}
	}
}