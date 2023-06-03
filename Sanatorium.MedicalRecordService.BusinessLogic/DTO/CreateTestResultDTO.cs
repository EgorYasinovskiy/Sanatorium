namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class CreateTestResultDTO
	{
		public string TextResult { get; set; }
		public string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }
	}
}
