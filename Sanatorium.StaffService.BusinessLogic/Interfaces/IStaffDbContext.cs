using Microsoft.EntityFrameworkCore;

using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.Interfaces
{
	public interface IStaffDbContext
	{
		DbSet<Staff> Patients { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
