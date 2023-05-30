namespace Sanatorium.MedicalRecordService.Model
{
	public class PatientDaignosis : HasPatientPropery
	{
		public DateOnly Date { get; set; }
		public Guid DiagnosisId { get; set; }
		public virtual Diagnosis Diagnosis { get; set; }
	}
}
