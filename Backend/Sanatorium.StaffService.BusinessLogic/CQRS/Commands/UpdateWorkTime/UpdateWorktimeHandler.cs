using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.UpdateWorkTime
{
	public class UpdateWorktimeHandler : RequestHandlerBase, IRequestHandler<UpdateWorkTime>
	{
		public UpdateWorktimeHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(UpdateWorkTime request, CancellationToken cancellationToken)
		{
			var record = await _workRecordRepository.GetById(request.RecordId, cancellationToken);
			if (record != null)
			{
				record.Hours = request.Hours;
				record.Date = request.Date;

				await _workRecordRepository.Update(record, cancellationToken);
				await _workRecordRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
