using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;
using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.RegisterNew
{
	public class RegisterNewHandler : RequestHandlerBase, IRequestHandler<RegisterNew, StaffDTO>
	{
		public RegisterNewHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task<StaffDTO> Handle(RegisterNew request, CancellationToken cancellationToken)
		{
			var manager = _staffRepository.GetById(request.CreateStaffDTO.ManagerId, cancellationToken);
			var staff = new Staff()
			{
				Id = Guid.NewGuid(),
				FirstName = request.CreateStaffDTO.FirstName,
				LastName = request.CreateStaffDTO.LastName,
				MiddleName = request.CreateStaffDTO.MiddleName,
				BirthDate = request.CreateStaffDTO.BirthDate,
				PhoneNumber = request.CreateStaffDTO.PhoneNumber,
				Position = request.CreateStaffDTO.Position,
				DayHoliday = request.CreateStaffDTO.DayHoliday,
				DayWork = request.CreateStaffDTO.DayWork,
				WorkStart = request.CreateStaffDTO.WorkStart,
				SalaryPerHour = request.CreateStaffDTO.SalaryPerHour,
				ManagerId = request.CreateStaffDTO.ManagerId,
				Manager = await manager
			};
			await _staffRepository.Create(staff, cancellationToken);
			await _staffRepository.SaveChanges(cancellationToken);
			var savedStaff = _staffRepository.GetById(staff.Id, cancellationToken);
			return _mapper.Map<StaffDTO>(await savedStaff);
		}
	}
}
