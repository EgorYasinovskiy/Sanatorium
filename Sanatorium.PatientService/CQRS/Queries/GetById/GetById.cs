using MediatR;

using Sanatorium.PatientService.DataModel;
using Sanatorium.PatientService.DTO;

namespace Sanatorium.PatientService.CQRS.Queries.GetById
{
	public class GetById : IRequest<PatientDTO>
	{
		public Guid Id { get; set; }
	}
}
