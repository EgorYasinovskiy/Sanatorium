namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class UpdateProceduralReffalDTO
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public Guid ProcedureTypeId { get; set; }
	}
}
