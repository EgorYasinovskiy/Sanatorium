using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IWorkRecordRepository
	{
		public Task Create(WorkRecord workRecord, CancellationToken cancellationToken);
		public Task<WorkRecord> GetById(Guid id, CancellationToken cancellationToken);
		public Task<IEnumerable<WorkRecord>> GetAll(CancellationToken cancellationToken);
		public Task DeleteById(Guid id, CancellationToken cancellationToken);
		public Task Update(WorkRecord workRecord, CancellationToken cancellationToken);
		public Task SaveChanges(CancellationToken cancellationToken);
		public Task<IEnumerable<WorkRecord>> GetByStaffId(Guid staffId, CancellationToken cancellationToken);
	}
}
