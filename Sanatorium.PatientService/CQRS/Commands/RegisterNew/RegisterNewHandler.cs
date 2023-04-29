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
			var patient = new Patient()
			{
				BirthDate = request.Patient.BirthDate,
				PhoneNumber = request.Patient.PhoneNumber,
				FirstName = request.Patient.FirstName,
				LastName = request.Patient.LastName,
				MiddleName = request.Patient.MiddleName,
				DateRegistered = DateOnly.FromDateTime(DateTime.Now),
				Id = Guid.NewGuid()
			};

			await _patientRepository.Create(patient, cancellationToken);
			await _patientRepository.SaveChanges(cancellationToken);

			return _mapper.Map<PatientDTO>(patient);
		}
	}
}
