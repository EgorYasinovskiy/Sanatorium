using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IStaffRepository
	{
		public Task Create(Staff patient, CancellationToken cancellationToken);
		public Task<Staff> GetById(Guid id, CancellationToken cancellationToken);
		public Task<IEnumerable<Staff>> GetAll(CancellationToken cancellationToken);
		public Task DeleteById(Guid id, CancellationToken cancellationToken);
		public Task Update(Staff patient, CancellationToken cancellationToken);
		public Task SaveChanges(CancellationToken cancellationToken);
	}
}
