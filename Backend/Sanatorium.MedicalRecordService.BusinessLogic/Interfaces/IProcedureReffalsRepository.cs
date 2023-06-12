using Sanatorium.Common;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.Interfaces
{
	public interface IProcedureReffalsRepository : IRepositoryBase<ProcedureReffal>
	{
		public Task<IEnumerable<ProcedureReffal>> GetReffalsByPatient(Guid patientId, DateTime start, DateTime end, CancellationToken cancellationToken);
		public Task<IEnumerable<ProcedureReffal>> GetReffalsByType(Guid typeId, DateTime start, DateTime end, CancellationToken cancellationToken);
	}
}
