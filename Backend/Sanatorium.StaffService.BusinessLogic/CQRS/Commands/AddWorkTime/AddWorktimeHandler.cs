using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.AddWorkTime
{
	public class AddWorktimeHandler : RequestHandlerBase, IRequestHandler<AddWorkTime>
	{
		public AddWorktimeHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(AddWorkTime request, CancellationToken cancellationToken)
		{
			var workRecord = new WorkRecord()
			{
				Date = request.Date,
				Hours = request.Hours,
				StaffId = request.StaffId,
				Id = Guid.NewGuid()
			};
			await _workRecordRepository.Create(workRecord, cancellationToken);
			await _workRecordRepository.SaveChanges(cancellationToken);
		}
	}
}
