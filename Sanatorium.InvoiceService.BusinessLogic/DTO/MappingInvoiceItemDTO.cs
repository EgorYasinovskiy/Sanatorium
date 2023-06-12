using AutoMapper;

using Sanatorium.Common.DTO;
using Sanatorium.Common.Mappings;
using Sanatorium.InvoiceService.BusinessLogic.DTO.ValueResolvers;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.DTO
{
	public class MappingInvoiceItemDTO : MapFrom<InvoiceItem>
	{

		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<InvoiceItem, InvoiceItemDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.InvoiceId, cfg => cfg.MapFrom(o => o.InvoiceId))
				.ForMember(dto => dto.Name, cfg => cfg.MapFrom(o => o.Name))
				.ForMember(dto => dto.Quanitity, cfg => cfg.MapFrom(o => o.Quanitity))
				.ForMember(dto => dto.Price, cfg => cfg.MapFrom(o => o.Price))
				.ForMember(dto => dto.Sum, cfg => cfg.MapFrom<SumValueResolver>())
				.ReverseMap();
		}
	}
}
