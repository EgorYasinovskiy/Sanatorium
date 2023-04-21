using AutoMapper;

using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew.Discharge
{
	public class DischargeHandler : RequestHandlerBase, IRequestHandler<Discharge>
	{

		public DischargeHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper){}

		public async Task Handle(Discharge request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.ID, cancellationToken);
			if (patient != null)
			{
				patient.Discharged = true;
				patient.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
				await _patientRepository.Update(patient, cancellationToken);
				await _patientRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
