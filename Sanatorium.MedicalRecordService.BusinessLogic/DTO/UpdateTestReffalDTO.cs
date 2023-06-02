namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class UpdateTestReffalDTO
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public Guid? TestResultId { get; set; }
		public Guid TestTypeId { get; set; }
	}
}
