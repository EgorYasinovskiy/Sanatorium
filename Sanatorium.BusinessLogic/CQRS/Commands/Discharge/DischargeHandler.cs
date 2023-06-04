using AutoMapper;

using MediatR;

using Sanatorium.PatientService.BusinessLogic.Interfaces;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.Discharge
{
	public class DischargeHandler : RequestHandlerBase, IRequestHandler<Discharge>
	{

		public DischargeHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper) { }

		public async Task Handle(Discharge request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.Id, cancellationToken);
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
