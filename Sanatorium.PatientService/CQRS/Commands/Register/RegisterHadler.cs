using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.Register
{
	public class RegisterHadler : CommandHandlerBase, IRequestHandler<Register>
	{
		
		public RegisterHadler(IPatientRepository patientRepository):base(patientRepository){}

		public async Task Handle(Register request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.Id, cancellationToken);
			if (patient != null)
			{
				patient.Discharged = false;
				patient.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
				await _patientRepository.Update(patient, cancellationToken);
				await _patientRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
