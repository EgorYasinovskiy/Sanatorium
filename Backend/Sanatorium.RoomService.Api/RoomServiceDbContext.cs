using Microsoft.EntityFrameworkCore;

using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.Api
{
	public class RoomServiceDbContext : DbContext, IRoomServiceDbContext

	{
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RoomMove> RoomMoves { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		public async Task<IEnumerable<Booking>> GetActualBookings(CancellationToken cancellationToken)
		{
			return await Bookings.Where(x => x.ArrivalDate.AddDays(x.DurationInDays) >= DateOnly.FromDateTime(DateTime.Now)).Include(x => x.Room).ToListAsync(cancellationToken);
		}
		public async Task<IEnumerable<Room>> GetFreeRoomsAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
		{
			var bookedRooms = await Bookings.Where(x => x.ArrivalDate.AddDays(x.DurationInDays) > start || x.ArrivalDate < end).Select(x => x.RoomId).Distinct().ToListAsync(cancellationToken);
			return Rooms.Where(x => x.IsFree && !bookedRooms.Contains(x.Id));
		}
	}
}
