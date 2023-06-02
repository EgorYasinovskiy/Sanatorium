namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class UpdateTestResultDTO
	{
		public Guid Id { get; set; }
		string TextResult { get; set; }
		string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }
	}
}
