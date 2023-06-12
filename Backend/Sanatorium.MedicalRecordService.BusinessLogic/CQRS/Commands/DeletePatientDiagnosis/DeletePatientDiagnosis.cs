using MediatR;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeletePatientDiagnosis
{
	public class DeletePatientDiagnosis : IRequest
	{
		public Guid Id { get; set; }
	}
}
