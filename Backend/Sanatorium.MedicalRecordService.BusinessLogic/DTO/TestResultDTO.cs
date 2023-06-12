using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class TestResultDTO : MapFrom<TestResult>
	{
		public Guid Id { get; set; }
		public string TextResult { get; set; }
		public string ResultFile { get; set; }
		public Guid TestReffalID { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<TestResult, TestResultDTO>()
				.ForMember(d => d.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(d => d.TextResult, cfg => cfg.MapFrom(o => o.TextResult))
				.ForMember(d => d.ResultFile, cfg => cfg.MapFrom(o => o.ResultFile))
				.ForMember(d => d.TestReffalID, cfg => cfg.MapFrom(o => o.TestReffalID));
		}
	}
}
