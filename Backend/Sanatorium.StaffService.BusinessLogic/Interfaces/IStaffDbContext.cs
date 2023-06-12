using Microsoft.EntityFrameworkCore;

using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IStaffDbContext
	{
		DbSet<Staff> Staff { get; set; }
		DbSet<WorkRecord> WorkRecords { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
