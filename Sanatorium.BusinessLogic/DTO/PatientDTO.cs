using AutoMapper;

using Sanatorium.Common.Mappings;

namespace Sanatorium.PatientService.BusinessLogic.DTO
{
	public class PatientDTO : MapFrom<Patient>
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }

		public DateOnly DateRegistered { get; set; }
		public DateOnly? DateDischarged { get; set; }
		public bool Discharged { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Patient, PatientDTO>().
				ForMember(pdto => pdto.Id
				, cfg => cfg.MapFrom(p => p.Id))
				.ForMember(pdto => pdto.FirstName
				, cfg => cfg.MapFrom(p => p.FirstName))
				.ForMember(pdto => pdto.LastName
				, cfg => cfg.MapFrom(p => p.LastName))
				.ForMember(pdto => pdto.MiddleName
				, cfg => cfg.MapFrom(p => p.MiddleName))
				.ForMember(pdto => pdto.BirthDate
				, cfg => cfg.MapFrom(p => p.BirthDate))
				.ForMember(pdto => pdto.PhoneNumber
				, cfg => cfg.MapFrom(p => p.PhoneNumber))
				.ForMember(pdto => pdto.DateRegistered
				, cfg => cfg.MapFrom(p => p.DateRegistered))
				.ForMember(pdto => pdto.DateDischarged
				, cfg => cfg.MapFrom(p => p.DateDischarged))
				.ForMember(pdto => pdto.Discharged
				, cfg => cfg.MapFrom(p => p.Discharged));
		}
	}
}
