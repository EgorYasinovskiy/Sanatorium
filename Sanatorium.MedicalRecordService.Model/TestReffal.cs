namespace Sanatorium.MedicalRecordService.Model
{
	public class TestReffal : HasPatientPropery
	{
		public DateTime DateTime { get; set; }
		public Guid? TestResultId { get; set; }
		public virtual TestResult TestResult { get; set; }
		public Guid TestTypeId { get; set; }
		public virtual TestType TestType { get; set; }
	}
}