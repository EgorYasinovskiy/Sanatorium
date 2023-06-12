using Sanatorium.Common;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.Interfaces
{
	public interface IRoomRepository : IRepositoryBase<Room>
	{
		public Task<IEnumerable<Room>> GetFree(CancellationToken cancellationToken, DateOnly start, DateOnly end);
	}
}
