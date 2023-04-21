using AutoMapper;

using MediatR;

using Sanatorium.PatientService.CQRS.Commands;
using Sanatorium.PatientService.DTO;

namespace Sanatorium.PatientService.CQRS.Queries.GetAll
{
	public class GetAllHandler : RequestHandlerBase, IRequestHandler<GetAll, PatientList>
	{
		
		public GetAllHandler(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
		{
		}

		public async Task<PatientList> Handle(GetAll request, CancellationToken cancellationToken)
		{
			var patients = await _patientRepository.GetAll(cancellationToken);
			var patientList = new PatientList();
			patientList.Patients = _mapper.Map<List<PatientListItem>>(patients);
			return patientList;
		}
	}
}
