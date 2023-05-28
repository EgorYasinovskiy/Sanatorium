using Microsoft.EntityFrameworkCore;

using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.Api.Repositories
{
	public class RoomRepository : IRoomRepository
	{
		private readonly IRoomServiceDbContext _dbContext;
		public RoomRepository(IRoomServiceDbContext dbContext) => _dbContext = dbContext;
		public async Task Create(Room entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.Rooms.Add(entity), cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
			if (room != null)
				_dbContext.Rooms.Remove(room);
		}

		public async Task<IEnumerable<Room>> GetAll(CancellationToken cancellationToken)
		{
			return await _dbContext.Rooms.ToListAsync(cancellationToken);
		}

		public async Task<Room> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _dbContext.Rooms.FirstAsync(r => r.Id == id, cancellationToken);
		}

		public async Task<IEnumerable<Room>> GetFree(CancellationToken cancellationToken, DateOnly start, DateOnly end)
		{
			return await _dbContext.GetFreeRoomsAsync(start, end, cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(Room entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.Rooms.Update(entity), cancellationToken);
		}
	}
}
