using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew.Discharge
{
    public class DischargeHandler : IRequestHandler<Discharge>
    {
        IPatientRepository _patientRepository;

        public DischargeHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

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
