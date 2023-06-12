using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.InventoryService.BusinessLogic.DTO.ValueResolvers;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class InventoryItemShortDTO : MapFrom<InventoryItem>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int NeedToBuy { get; set; }
		public double TotalSum { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<InventoryItem, InventoryItemShortDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.Name, cfg => cfg.MapFrom(o => o.Name))
				.ForMember(dto => dto.NeedToBuy, cfg => cfg.MapFrom<NeedToByResolver>())
				.ForMember(dto => dto.TotalSum, cfg => cfg.MapFrom<TotalSumResolver>());
		}
	}
}
