using Microsoft.EntityFrameworkCore;

using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.Api.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly IRoomServiceDbContext _dbContext;

		public BookingRepository(IRoomServiceDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task Create(Booking entity, CancellationToken cancellationToken)
		{
			await _dbContext.Bookings.AddAsync(entity, cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var booking = await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (booking != null)
				await Task.Run(() => _dbContext.Bookings.Remove(booking), cancellationToken);
		}

		public async Task<IEnumerable<Booking>> GetActual(CancellationToken cancellationToken)
		{
			return await _dbContext.GetActualBookings(cancellationToken);
		}

		public async Task<IEnumerable<Booking>> GetAll(CancellationToken cancellationToken)
		{
			return await _dbContext.Bookings.ToListAsync(cancellationToken);
		}

		public async Task<Booking> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Booking entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.Bookings.Update(entity), cancellationToken);
		}
	}
}
