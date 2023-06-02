namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class CreateProceduralReffalDTO
	{
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public Guid ProcedureTypeId { get; set; }
	}
}
