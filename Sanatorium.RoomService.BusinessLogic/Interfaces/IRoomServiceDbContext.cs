using Microsoft.EntityFrameworkCore;

using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.Interfaces
{
	public interface IRoomServiceDbContext
	{
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RoomMove> RoomMoves { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
		public Task<IEnumerable<Booking>> GetActualBookings(CancellationToken cancellationToken);
		public Task<IEnumerable<Room>> GetFreeRoomsAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);

	}
}
