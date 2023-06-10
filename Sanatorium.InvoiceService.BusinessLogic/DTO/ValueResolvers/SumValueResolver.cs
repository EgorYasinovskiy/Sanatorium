using AutoMapper;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.DTO.ValueResolvers
{
	internal class SumValueResolver : IValueResolver<InvoiceItem, InvoiceItemDTO, double>
	{
		public double Resolve(InvoiceItem source, InvoiceItemDTO destination, double destMember, ResolutionContext context)
		{
			return source.Price * source.Quanitity;
		}
	}
}
