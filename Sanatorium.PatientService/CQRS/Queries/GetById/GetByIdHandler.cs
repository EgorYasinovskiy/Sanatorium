using AutoMapper;

using MediatR;

using Sanatorium.PatientService.CQRS.Commands;
using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.CQRS.Queries.GetById
{
	public class GetByIdHandler : RequestHandlerBase, IRequestHandler<GetById, Patient>
	{
		public GetByIdHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
		{
		}

		public async Task<Patient> Handle(GetById request, CancellationToken cancellationToken)
		{
			var pacient = await _patientRepository.GetById(request.Id, cancellationToken);
			return pacient;
		}
	}
}
