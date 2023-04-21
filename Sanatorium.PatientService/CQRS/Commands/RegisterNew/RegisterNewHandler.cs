using MediatR;

using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew
{
	public class RegisterNewHandler : IRequestHandler<RegisterNew>
	{
		IPatientRepository _patientRepository;

		public async Task Handle(RegisterNew request, CancellationToken cancellationToken)
		{
			var patient = new Patient();
			patient.BirthDate = request.BirthDate;
			patient.PhoneNumber = request.PhoneNumber;
			patient.FirstName = request.FirstName;
			patient.LastName = request.LastName;
			patient.MiddleName= request.MiddleName;
			patient.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
			patient.Id = Guid.NewGuid();

			await _patientRepository.Create(patient, cancellationToken);
			await _patientRepository.SaveChanges(cancellationToken);
		}
	}
}
