using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class ProcedureReffalDTO : MapFrom<ProcedureReffal>
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public ProcedureTypeDTO ProcedureType { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<ProcedureReffal, ProcedureReffalDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.PatientId, cfg => cfg.MapFrom(o => o.PatientId))
				.ForMember(dto => dto.DateTime, cfg => cfg.MapFrom(o => o.DateTime))
				.ForMember(dto => dto.ProcedureType, cfg => cfg.MapFrom(o => o.ProcedureType));
		}
	}
}
