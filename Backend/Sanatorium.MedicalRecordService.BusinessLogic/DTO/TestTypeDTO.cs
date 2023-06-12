using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.DTO
{
	public class TestTypeDTO : MapFrom<TestType>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<TestType, TestTypeDTO>()
				.ForMember(dto => dto.Name, cfg => cfg.MapFrom(o => o.Name))
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.Price, cfg => cfg.MapFrom(o => o.Price));
		}
	}
}
