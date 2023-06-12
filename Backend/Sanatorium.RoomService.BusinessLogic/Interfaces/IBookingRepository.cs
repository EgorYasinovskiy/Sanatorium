using Sanatorium.Common;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.Interfaces
{
	public interface IBookingRepository : IRepositoryBase<Booking>
	{
		public Task<IEnumerable<Booking>> GetActual(CancellationToken cancellationToken);
	}
}
