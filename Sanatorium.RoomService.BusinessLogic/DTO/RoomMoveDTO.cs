using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.RoomService.Model;

namespace Sanatorium.RoomService.BusinessLogic.DTO
{
	public class RoomMoveDTO : MapFrom<RoomMove>
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public int OldRoomNumber { get; set; }
		public int NewRoomNumber { get; set; }
		public DateOnly Date { get; set; }
		public RoomMoveType MoveType { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<RoomMove, RoomMoveDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(rm => rm.Id))
				.ForMember(dto => dto.PatientId, cfg => cfg.MapFrom(rm => rm.PatientId))
				.ForMember(dto => dto.OldRoomNumber, cfg => cfg.MapFrom(rm => rm.OldRoom.RoomNumber))
				.ForMember(dto => dto.NewRoomNumber, cfg => cfg.MapFrom(rm => rm.NewRoom.RoomNumber))
				.ForMember(dto => dto.Date, cfg => cfg.MapFrom(rm => rm.Date))
				.ForMember(dto => dto.MoveType, cfg => cfg.MapFrom(rm => rm.MoveType));
		}
	}
}
