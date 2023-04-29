using AutoMapper;

namespace Sanatorium.PatientService.Mappings
{
	public interface MapFrom<T> where T : class
	{
		public void CreateMapping(Profile profile) =>
			profile.CreateMap(typeof(T), GetType());
	}
}
