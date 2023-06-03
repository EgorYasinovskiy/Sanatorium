namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class UpdateTestResultDTO
	{
		public Guid Id { get; set; }
		public string TextResult { get; set; }
		public string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }
	}
}
