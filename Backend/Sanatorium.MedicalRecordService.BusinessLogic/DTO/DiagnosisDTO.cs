using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class DiagnosisDTO : MapFrom<Diagnosis>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Diagnosis, DiagnosisDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.Name, cfg => cfg.MapFrom(o => o.Name));
		}
	}
}
