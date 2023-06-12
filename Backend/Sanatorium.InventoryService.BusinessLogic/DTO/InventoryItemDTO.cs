using AutoMapper;

using Sanatorium.Common.Mappings;
using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO
{
	public class InventoryItemDTO : MapFrom<InventoryItem>
	{
		public Guid Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int RequiredQuantity { get; set; }

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<InventoryItem, InventoryItemDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.Price, cfg => cfg.MapFrom(o => o.Price))
				.ForMember(dto => dto.Name, cfg => cfg.MapFrom(o => o.Name))
				.ForMember(dto => dto.Quantity, cfg => cfg.MapFrom(o => o.Quantity))
				.ForMember(dto => dto.RequiredQuantity, cfg => cfg.MapFrom(o => o.RequiredQuantity));
		}
	}
}
