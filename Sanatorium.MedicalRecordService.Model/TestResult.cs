namespace Sanatorium.MedicalRecordService.Model
{
	public class TestResult
	{
		public Guid Id { get; set; }
		string TextResult { get; set; }
		string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }
		public virtual TestReffal TestReffal { get; set; }
	}
}
