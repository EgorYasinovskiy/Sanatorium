namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class CreatePatientDiagnosisDTO
	{
		public DateOnly Date { get; set; }
		public Guid PatientId { get; set; }
		public Guid DiagnosisId { get; set; }
	}
}
