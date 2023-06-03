using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByPatient
{
	public class GetTestReffalsByPatient : IRequest<TestReffalsListDTO>
	{
		public Guid PatientId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
