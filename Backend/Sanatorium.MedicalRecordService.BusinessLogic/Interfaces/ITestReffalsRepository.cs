using Sanatorium.Common;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.Interfaces
{
	public interface ITestReffalsRepository : IRepositoryBase<TestReffal>
	{
		public Task<IEnumerable<TestReffal>> GetByPatientId(Guid patientId, DateTime start, DateTime end, CancellationToken cancellationToken);
		public Task<IEnumerable<TestReffal>> GetByTypeId(Guid typeId, DateTime start, DateTime end, CancellationToken cancellationToken);
	}
}
