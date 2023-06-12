using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.DTO
{
	public class StaffListItem : MapFrom<Staff>
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Staff, StaffListItem>()
				.ForMember(sli => sli.Id, cfg => cfg.MapFrom(staff => staff.Id))
				.ForMember(sli => sli.FirstName, cfg => cfg.MapFrom(staff => staff.FirstName))
				.ForMember(sli => sli.MiddleName, cfg => cfg.MapFrom(staff => staff.MiddleName))
				.ForMember(sli => sli.LastName, cfg => cfg.MapFrom(staff => staff.LastName))
				.ForMember(sli => sli.BirthDate, cfg => cfg.MapFrom(staff => staff.BirthDate))
				.ForMember(sli => sli.PhoneNumber, cfg => cfg.MapFrom(staff => staff.PhoneNumber));
		}
	}
}
