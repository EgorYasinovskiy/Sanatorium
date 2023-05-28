using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class BookingDTO : MapFrom<Booking>
	{
		public Guid Id { get; set; }
		public Guid RoomId { get; set; }
		public int RoomNumber { get; set; }
		public DateOnly ArrivalDate { get; set; }
		public int DurationInDays { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Booking, BookingDTO>()
				.ForMember(bdto => bdto.Id, cfg => cfg.MapFrom(b => b.Id))
				.ForMember(bdto => bdto.RoomId, cfg => cfg.MapFrom(b => b.RoomId))
				.ForMember(bdto => bdto.ArrivalDate, cfg => cfg.MapFrom(b => b.ArrivalDate))
				.ForMember(bdto => bdto.RoomNumber, cfg => cfg.MapFrom(b => b.Room.RoomNumber))
				.ForMember(bdto => bdto.DurationInDays, cfg => cfg.MapFrom(b => b.DurationInDays));
		}
	}
}
