using MediatR;

using Sanatorium.PatientService.BusinessLogic.DTO;

namespace Sanatorium.PatientService.BusinessLogic.CQRS.Queries.GetAll
{

	public class GetAll : IRequest<PatientList>
	{

	}
}
