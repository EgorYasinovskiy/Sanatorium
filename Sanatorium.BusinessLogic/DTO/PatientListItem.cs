using AutoMapper;

using Sanatorium.PatientService.BusinessLogic.Mappings;
using Sanatorium.PatientService.Model;

namespace Sanatorium.PatientService.BusinessLogic.DTO
{
	public class PatientListItem : MapFrom<Patient>
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Patient, PatientListItem>().
				ForMember(patientLI => patientLI.Id
				, cfg => cfg.MapFrom(p => p.Id))
				.ForMember(pli => pli.FirstName
				, cfg => cfg.MapFrom(p => p.FirstName))
				.ForMember(pli => pli.LastName
				, cfg => cfg.MapFrom(p => p.LastName))
				.ForMember(pli => pli.MiddleName
				, cfg => cfg.MapFrom(p => p.MiddleName));
		}
	}
}
