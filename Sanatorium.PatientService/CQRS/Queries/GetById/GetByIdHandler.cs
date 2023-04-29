using AutoMapper;

using MediatR;

using Sanatorium.PatientService.DTO;
using Sanatorium.PatientService.Interfaces;

namespace Sanatorium.PatientService.CQRS.Queries.GetById
{
	public class GetByIdHandler : RequestHandlerBase, IRequestHandler<GetById, PatientDTO>
	{
		public GetByIdHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
		{
		}

		public async Task<PatientDTO> Handle(GetById request, CancellationToken cancellationToken)
		{
			var patient = await _patientRepository.GetById(request.Id, cancellationToken);
			var patientdto = _mapper.Map<PatientDTO>(patient);
			return patientdto;
		}
	}
}
