using AutoMapper;

using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.BusinessLogic.DTO.ValueResolvers
{
	public class TotalSumResolver : IValueResolver<InventoryItem, InventoryItemShortDTO, double>
	{
		public double Resolve(InventoryItem source, InventoryItemShortDTO destination, double destMember, ResolutionContext context)
		{
			if(source.Quantity < source.RequiredQuantity)
			{
				return source.Price * (source.RequiredQuantity - source.Quantity);
			}
			return 0;
		}
	}
}
