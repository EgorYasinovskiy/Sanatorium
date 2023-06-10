using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class RoomMoveDTO : MapFrom<RoomMove>
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public int RoomNumber { get; set; }
		public Guid RoomId { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<RoomMove, RoomMoveDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(rm => rm.Id))
				.ForMember(dto => dto.PatientId, cfg => cfg.MapFrom(rm => rm.PatientId))
				.ForMember(dto => dto.RoomNumber, cfg => cfg.MapFrom(rm => rm.Room.RoomNumber))
				.ForMember(dto => dto.RoomId, cfg => cfg.MapFrom(rm => rm.RoomId))
				.ForMember(dto => dto.Date, cfg => cfg.MapFrom(rm => rm.Date))
				.ForMember(dto => dto.MoveType, cfg => cfg.MapFrom(rm => rm.MoveType));
		}
	}
}
