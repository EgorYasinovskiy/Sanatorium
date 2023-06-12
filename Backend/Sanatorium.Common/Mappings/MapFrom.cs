using AutoMapper;

namespace Sanatorium.Common.Mappings
{
	public interface MapFrom<T> where T : class
	{
		public virtual void CreateMapping(Profile profile) =>
			profile.CreateMap(typeof(T), GetType());
	}
}
