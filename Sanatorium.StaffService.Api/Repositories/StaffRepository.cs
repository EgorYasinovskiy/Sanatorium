using Microsoft.EntityFrameworkCore;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.Api.Repositories
{
	public class StaffRepository : IStaffRepository
	{
		private readonly IStaffDbContext _staffDbContext;

		public StaffRepository(IStaffDbContext staffDbContext)
		{
			_staffDbContext = staffDbContext;
		}

		public async Task Create(Staff staff, CancellationToken cancellationToken)
		{
			await _staffDbContext.Staff.AddAsync(staff, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var staff = await _staffDbContext.Staff.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (staff != null)
			{
				_staffDbContext.Staff.Remove(staff);
			}
		}

		public async Task<IEnumerable<Staff>> GetAll(CancellationToken cancellationToken)
		{
			return await _staffDbContext.Staff.ToListAsync(cancellationToken);
		}

		public async Task<Staff> GetById(Guid id, CancellationToken cancellationToken)
		{
			var staff = _staffDbContext.Staff.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return await staff;
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _staffDbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Staff staff, CancellationToken cancellationToken)
		{
			if (staff != null)
				await Task.Run(() => _staffDbContext.Staff.Update(staff));

		}
	}
}
