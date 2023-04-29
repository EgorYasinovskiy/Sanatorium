﻿using AutoMapper;

using MediatR;

using Sanatorium.PatientService.DataModel;
using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService.CQRS.Commands.RegisterNew
{
	public class RegisterNewHandler : RequestHandlerBase, IRequestHandler<RegisterNew>
	{

		public RegisterNewHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper) { }

		public async Task Handle(RegisterNew request, CancellationToken cancellationToken)
		{
			var patient = new Patient();
			patient.BirthDate = request.BirthDate;
			patient.PhoneNumber = request.PhoneNumber;
			patient.FirstName = request.FirstName;
			patient.LastName = request.LastName;
			patient.MiddleName = request.MiddleName;
			patient.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
			patient.Id = Guid.NewGuid();

			await _patientRepository.Create(patient, cancellationToken);
			await _patientRepository.SaveChanges(cancellationToken);
		}
	}
}
