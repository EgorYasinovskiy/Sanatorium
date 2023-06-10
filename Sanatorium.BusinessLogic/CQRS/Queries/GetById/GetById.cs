using MediatR;

using Sanatorium.PatientService.BusinessLogic.DTO;
namespace Sanatorium.PatientService.BusinessLogic.CQRS.Queries.GetById
{
	public class GetById : IRequest<PatientDTO>
	{
		public Guid Id { get; set; }
	}
}
