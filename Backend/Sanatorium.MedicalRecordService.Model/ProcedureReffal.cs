namespace Sanatorium.MedicalRecordService.Model
{
	public class ProcedureReffal : HasPatientPropery
	{
		public DateTime DateTime { get; set; }
		public Guid ProcedureTypeId { get; set; }
		public virtual ProcedureType ProcedureType { get; set; }
	}
}
