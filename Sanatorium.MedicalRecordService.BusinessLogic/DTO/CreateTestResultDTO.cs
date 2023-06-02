namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class CreateTestResultDTO
	{
		string TextResult { get; set; }
		string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }
	}
}
