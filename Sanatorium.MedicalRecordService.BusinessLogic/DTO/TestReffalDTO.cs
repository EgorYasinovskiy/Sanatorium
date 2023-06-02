using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class TestReffalDTO : MapFrom<TestReffal>
	{
		public Guid Id { get; set; }
		public Guid PatientId { get; set; }
		public DateTime DateTime { get; set; }
		public TestResultDTO TestResult { get; set; }
		public TestTypeDTO TestType { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<TestReffal, TestReffalDTO>()
				.ForMember(dto => dto.DateTime, cfg => cfg.MapFrom(o => o.DateTime))
				.ForMember(dto => dto.TestResult, cfg => cfg.MapFrom(o => o.TestResult))
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.PatientId, cfg => cfg.MapFrom(o => o.PatientId))
				.ForMember(dto => dto.TestType, cfg => cfg.MapFrom(o => o.TestType));
		}
	}
}
