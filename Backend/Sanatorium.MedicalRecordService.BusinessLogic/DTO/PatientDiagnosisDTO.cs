using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class PatientDiagnosisDTO : MapFrom<PatientDaignosis>
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public DateOnly Date { get; set; }
		public DiagnosisDTO Diagnosis { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<PatientDaignosis, PatientDiagnosisDTO>()
		.ForMember(dto => dto.Date, cfg => cfg.MapFrom(o => o.Date))
		.ForMember(dto => dto.PatientId, cfg => cfg.MapFrom(o => o.PatientId))
		.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
		.ForMember(dto => dto.Diagnosis, cfg => cfg.MapFrom(o => o.Diagnosis));
		}
	}
}
