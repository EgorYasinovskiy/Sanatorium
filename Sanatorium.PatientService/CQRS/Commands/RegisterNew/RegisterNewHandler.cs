using AutoMapper;

using MediatR;

using Sanatorium.PatientService.DataModel;
using Sanatorium.PatientService.DTO;
using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew
{
	public class RegisterNewHandler : RequestHandlerBase, IRequestHandler<RegisterNew, PatientDTO>
	{

		public RegisterNewHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper) { }

		public async Task<PatientDTO> Handle(RegisterNew request, CancellationToken cancellationToken)
		{
			var patient = new Patient();
			patient.BirthDate = request.Patient.BirthDate;
			patient.PhoneNumber = request.Patient.PhoneNumber;
			patient.FirstName = request.Patient.FirstName;
			patient.LastName = request.Patient.LastName;
			patient.MiddleName = request.Patient.MiddleName;
			patient.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
			patient.Id = Guid.NewGuid();

			await _patientRepository.Create(patient, cancellationToken);
			await _patientRepository.SaveChanges(cancellationToken);

			return _mapper.Map<PatientDTO>(patient);
		}
	}
}
