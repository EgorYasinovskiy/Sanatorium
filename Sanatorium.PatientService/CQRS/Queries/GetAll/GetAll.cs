using MediatR;

namespace Sanatorium.PatientService.CQRS.Queries.GetAll
{

	public class GetAll : IRequest<DTO.PatientList>
	{

	}
}
