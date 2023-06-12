using AutoMapper;

using Sanatorium.Common.DTO;
using Sanatorium.Common.Mappings;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.DTO
{
	public class MappingInvoiceDTO : InvoiceDTO, MapFrom<Invoice>
	{
		public void CreateMapping(Profile profile)
		{
			profile.CreateMap<Invoice, InvoiceDTO>()
				.ForMember(dto => dto.Id, cfg => cfg.MapFrom(o => o.Id))
				.ForMember(dto => dto.ParentId, cfg => cfg.MapFrom(o => o.ParentId))
				.ForMember(dto => dto.DateFrom, cfg => cfg.MapFrom(o => o.DateFrom))
				.ForMember(dto => dto.PayDate, cfg => cfg.MapFrom(o => o.PayDate))
				.ForMember(dto => dto.Payed, cfg => cfg.MapFrom(o => o.Payed))
				.ForMember(dto => dto.Items, cfg => cfg.MapFrom(o => o.Items))
				.ReverseMap();
		}
	}
}
