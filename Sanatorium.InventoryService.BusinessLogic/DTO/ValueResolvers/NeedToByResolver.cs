using AutoMapper;

using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO.ValueResolvers
{
	public class NeedToByResolver : IValueResolver<InventoryItem, InventoryItemShortDTO, int>
	{
		public int Resolve(InventoryItem source, InventoryItemShortDTO destination, int destMember, ResolutionContext context)
		{
			if(source.Quantity < source.RequiredQuantity) 
			{
				return source.RequiredQuantity - source.Quantity;
			}
			return 0;
		}
	}
}
