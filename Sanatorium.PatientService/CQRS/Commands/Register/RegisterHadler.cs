using AutoMapper;

using MediatR;

using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService.CQRS.Commands.Register
{
	public class RegisterHadler : RequestHandlerBase, IRequestHandler<Register>
	{
		
		public RegisterHadler(IPatientRepository patientRepository, IMapper mapper): base(patientRepository, mapper) {}

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
