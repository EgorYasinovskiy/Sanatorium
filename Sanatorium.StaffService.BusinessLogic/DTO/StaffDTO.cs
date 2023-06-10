using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.StaffService.BusinessLogic.DTO.ValueResolvers;
using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.DTO
{
	public class StaffDTO : MapFrom<Staff>
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }
		public int CabinetNumber { get; set; }
		public string Position { get; set; }
		public Guid ManagerId { get; set; }
		public string ManagerName { get; set; }
		public int DayWork { get; set; }
		public int DayHoliday { get; set; }
		public DateOnly WorkStart { get; set; }
		public double SalaryPerHour { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Staff, StaffDTO>().
				ForMember(sdto => sdto.Id,
				cfg => cfg.MapFrom(s => s.Id)).
				ForMember(sdto => sdto.FirstName,
				  cfg => cfg.MapFrom(s => s.FirstName)).
				ForMember(sdto => sdto.MiddleName,
				cfg => cfg.MapFrom(s => s.MiddleName)).
				ForMember(sdto => sdto.LastName,
				  cfg => cfg.MapFrom(s => s.LastName)).
				ForMember(sdto => sdto.BirthDate,
				  cfg => cfg.MapFrom(s => s.BirthDate)).
				ForMember(sdto => sdto.PhoneNumber,
				  cfg => cfg.MapFrom(s => s.PhoneNumber)).
				ForMember(sdto => sdto.CabinetNumber,
				  cfg => cfg.MapFrom(s => s.CabinetNumber)).
				ForMember(sdto => sdto.Position,
				  cfg => cfg.MapFrom(s => s.Position)).
				ForMember(sdto => sdto.ManagerId,
				  cfg => cfg.MapFrom(s => s.ManagerId)).
				ForMember(sdto => sdto.ManagerName,
				  cfg => cfg.MapFrom<ManagerNameValueResolver>()).
				ForMember(sdto => sdto.DayWork,
				  cfg => cfg.MapFrom(s => s.DayWork)).
				ForMember(sdto => sdto.DayHoliday,
				  cfg => cfg.MapFrom(s => s.DayHoliday)).
				ForMember(sdto => sdto.WorkStart,
				  cfg => cfg.MapFrom(s => s.WorkStart)).
				ForMember(sdto => sdto.SalaryPerHour,
				  cfg => cfg.MapFrom(s => s.SalaryPerHour));

		}
	}
}
