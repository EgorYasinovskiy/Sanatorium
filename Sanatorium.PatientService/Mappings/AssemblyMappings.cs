using System.Reflection;

using AutoMapper;

namespace Sanatorium.PatientService.Mappings
{
	public class AssemblyMappings : Profile
	{
		public AssemblyMappings(Assembly assembly) =>
			ApplyAssemblyMappings(assembly);

		private void ApplyAssemblyMappings(Assembly assembly)
		{
			assembly.GetExportedTypes().Where(type => type.GetInterfaces()
			.Any(i => i.IsGenericType &&
				i.GetGenericTypeDefinition() == typeof(MapFrom<>))).ToList();
		}
	}
}
