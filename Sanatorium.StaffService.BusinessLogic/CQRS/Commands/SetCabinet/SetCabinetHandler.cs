using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.SetCabinet
{
	public class SetCabinetHandler : RequestHandlerBase, IRequestHandler<SetCabinet>
	{
		public SetCabinetHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(SetCabinet request, CancellationToken cancellationToken)
		{
			var staff= await _staffRepository.GetById(request.StaffId, cancellationToken);
			if(staff != null)
			{
				staff.CabinetNumber = request.NewCabinet;
				await _staffRepository.Update(staff,cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
