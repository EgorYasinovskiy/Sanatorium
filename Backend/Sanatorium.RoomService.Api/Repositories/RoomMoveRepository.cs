using Microsoft.EntityFrameworkCore;

using Sanatorium.RoomService.BusinessLogic.Interfaces;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.Api.Repositories
{
	public class RoomMoveRepository : IRoomMoveRepository
	{
		private readonly IRoomServiceDbContext _dbContext;
		public RoomMoveRepository(IRoomServiceDbContext dbContext) => _dbContext = dbContext;

		public async Task Create(RoomMove entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.RoomMoves.Add(entity), cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var rm = await _dbContext.RoomMoves.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (rm != null)
				_dbContext.RoomMoves.Remove(rm);
		}

		public async Task<IEnumerable<RoomMove>> GetAll(CancellationToken cancellationToken)
		{
			return await _dbContext.RoomMoves.ToListAsync(cancellationToken);
		}

		public async Task<RoomMove> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _dbContext.RoomMoves.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public async Task<IEnumerable<RoomMove>> GetByPatientId(Guid patientId, CancellationToken cancellationToken)
		{
			return await _dbContext.RoomMoves.Where(x => x.PatientId == patientId).ToListAsync(cancellationToken);
		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(RoomMove entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _dbContext.RoomMoves.Update(entity), cancellationToken);
		}
	}
}
