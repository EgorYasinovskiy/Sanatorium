using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByPatient
{
	public class GetProcedureReffalsByPatient : IRequest<ProcedureReffalsListDTO>
	{
		public Guid PatientId { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
