using Sanatorium.Common;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.Interfaces
{
	public interface IRoomMoveRepository : IRepositoryBase<RoomMove>
	{
		public Task<IEnumerable<RoomMove>> GetByPatientId(Guid patientId, CancellationToken cancellationToken);
	}
}
