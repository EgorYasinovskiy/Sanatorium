using AutoMapper;

using Sanatorium.StaffService.Model;

namespace Sanatorium.StaffService.BusinessLogic.DTO.ValueResolvers
{
	public class ManagerNameValueResolver : IValueResolver<Staff, StaffDTO, string>
	{
		public string Resolve(Staff source, StaffDTO destination, string destMember, ResolutionContext context)
		{
			return source.Manager == null ? source.Manager.GetDisplayString() : ""
		}
	}
}
