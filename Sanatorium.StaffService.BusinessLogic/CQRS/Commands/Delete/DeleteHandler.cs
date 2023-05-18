using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.Delete
{
	public class DeleteHandler : RequestHandlerBase, IRequestHandler<Delete>
	{
		public DeleteHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(Delete request, CancellationToken cancellationToken)
		{
			await _staffRepository.DeleteById(request.StaffId, cancellationToken);
			await _staffRepository.SaveChanges(cancellationToken);
		}
	}
}
