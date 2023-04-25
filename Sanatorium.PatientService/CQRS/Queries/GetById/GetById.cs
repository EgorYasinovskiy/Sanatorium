using MediatR;

using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.CQRS.Queries.GetById
{
	public class GetById : IRequest<Patient>
	{
		public Guid Id { get; set; }
	}
}
