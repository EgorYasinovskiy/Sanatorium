using Microsoft.EntityFrameworkCore;

using Sanatorium.StaffService.BusinessLogic.Interfaces;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.Api
{
	public class StaffServiceDbContext : DbContext, IStaffDbContext
	{
		public DbSet<Staff> Staff { get; set; }
		public DbSet<WorkRecord> WorkRecords { get; set; }

		public StaffServiceDbContext(DbContextOptions<StaffServiceDbContext> options) : base(options) { }
	}
}
