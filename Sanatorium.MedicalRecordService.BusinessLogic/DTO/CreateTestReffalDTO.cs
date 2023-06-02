namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class CreateTestReffalDTO
	{
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public Guid TestTypeId { get; set; }
	}
}
