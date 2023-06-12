using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.ChangeSalary
{
	public class ChangeSalaryHandler : RequestHandlerBase, IRequestHandler<ChangeSalary>
	{
		public ChangeSalaryHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(ChangeSalary request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.StaffId, cancellationToken);
			if (staff != null)
			{
				staff.SalaryPerHour = request.NewSalaryPerHour;
				await _staffRepository.Update(staff, cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
