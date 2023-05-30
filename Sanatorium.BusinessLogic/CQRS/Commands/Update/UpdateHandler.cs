using AutoMapper;

using MediatR;

using Sanatorium.PatientService.BusinessLogic.EntityConfigurations.Interfaces;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.Update
{
	public class UpdateHandler : RequestHandlerBase, IRequestHandler<Update>
	{
		public UpdateHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
		{
		}

		public async Task Handle(Update request, CancellationToken cancellationToken)
		{
			var pacient = await _patientRepository.GetById(request.NewPatient.Id, cancellationToken);
			if (pacient != null)
			{
				pacient.BirthDate = request.NewPatient.BirthDate;
				pacient.FirstName = request.NewPatient.FirstName;
				pacient.LastName = request.NewPatient.LastName;
				pacient.MiddleName = request.NewPatient.MiddleName;
				pacient.PhoneNumber = request.NewPatient.PhoneNumber;

				await _patientRepository.Update(pacient, cancellationToken);
			}
		}
	}
}
