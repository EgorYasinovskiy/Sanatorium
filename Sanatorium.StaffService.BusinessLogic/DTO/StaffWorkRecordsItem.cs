using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.DTO
{
	public class StaffWorkRecordsItem : MapFrom<WorkRecord>
	{
		public Guid Id { get; set; }
		public DateOnly Date { get; set; }
		public double Hours { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<WorkRecord, StaffWorkRecordsItem>()
				.ForMember(wri => wri.Id, cfg => cfg.MapFrom(wr => wr.Id))
				.ForMember(wri => wri.Date, cfg => cfg.MapFrom(wr => wr.Date))
				.ForMember(wri => wri.Hours, cfg => cfg.MapFrom(wr => wr.Hours));
		}
	}
}
