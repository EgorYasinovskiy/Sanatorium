﻿using MediatR;

using Sanatorium.PatientService.BusinessLogic.DTO;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Commands.Update
{
	public class Update : IRequest
	{
		public PatientUpdateDTO NewPatient { get; set; }
	}
}
