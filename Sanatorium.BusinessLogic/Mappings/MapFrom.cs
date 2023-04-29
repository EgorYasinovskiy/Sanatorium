using AutoMapper;

namespace Sanatorium.PatientService.BusinessLogic.Mappings
{
	public interface MapFrom<T> where T : class
	{
		public void CreateMapping(Profile profile) =>
			profile.CreateMap(typeof(T), GetType());
	}
}
