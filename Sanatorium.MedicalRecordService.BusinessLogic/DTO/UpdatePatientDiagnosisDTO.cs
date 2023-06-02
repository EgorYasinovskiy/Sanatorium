namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class UpdatePatientDiagnosisDTO
	{
		public Guid Id { get; set; }
		public DateOnly Date { get; set; }
		public Guid PatientId { get; set; }
		public Guid DiagnosisId { get; set; }
	}
}
