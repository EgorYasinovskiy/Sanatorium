using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class RoomDTO : MapFrom<Room>
	{
		public Guid Id { get; set; }
		public int RoomNumber { get; set; }
		public int BedsCount { get; set; }
		public bool IsFree { get; set; }
		public double CostPerDay { get; set; }
		public int Category { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Room, RoomDTO>()
				.ForMember(rdto => rdto.Id, cfg => cfg.MapFrom(r => r.Id))
				.ForMember(rdto => rdto.BedsCount, cfg => cfg.MapFrom(r => r.BedsCount))
				.ForMember(rdto => rdto.IsFree, cfg => cfg.MapFrom(r => r.IsFree))
				.ForMember(rdto => rdto.CostPerDay, cfg => cfg.MapFrom(r => r.CostPerDay))
				.ForMember(rdto => rdto.RoomNumber, cfg => cfg.MapFrom(r => r.RoomNumber))
				.ForMember(rdto => rdto.Category, cfg => cfg.MapFrom(r => r.Category));
		}
	}
}
