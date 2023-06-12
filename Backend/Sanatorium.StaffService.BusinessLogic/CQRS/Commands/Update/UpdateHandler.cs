using AutoMapper;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.Interfaces;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.Update
{
	public class UpdateHandler : RequestHandlerBase, IRequestHandler<Update>
	{
		public UpdateHandler(IStaffRepository staffRepository, IWorkRecordRepository workRecordRepository, IMapper mapper) : base(staffRepository, workRecordRepository, mapper)
		{
		}

		public async Task Handle(Update request, CancellationToken cancellationToken)
		{
			var staff = await _staffRepository.GetById(request.UpdateStaffDTO.Id, cancellationToken);
			if (staff != null)
			{
				staff.FirstName = request.UpdateStaffDTO.FirstName;
				staff.LastName = request.UpdateStaffDTO.LastName;
				staff.MiddleName = request.UpdateStaffDTO.MiddleName;
				staff.BirthDate = request.UpdateStaffDTO.Birthdate;
				staff.PhoneNumber = request.UpdateStaffDTO.PhoneNumber;

				await _staffRepository.Update(staff, cancellationToken);
				await _staffRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
