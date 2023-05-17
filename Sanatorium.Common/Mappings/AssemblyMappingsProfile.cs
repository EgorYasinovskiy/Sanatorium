using System.Reflection;

using AutoMapper;

namespace Sanatorium.Common.Mappings
{
	public class AssemblyMappingsProfile : Profile
	{
		public AssemblyMappingsProfile(Assembly assembly) =>
			ApplyAssemblyMappings(assembly);

		private void ApplyAssemblyMappings(Assembly assembly)
		{
			var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces()
			.Any(i => i.IsGenericType &&
				i.GetGenericTypeDefinition() == typeof(MapFrom<>))).ToList();

			foreach (var type in types)
			{
				var instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("CreateMapping");
				methodInfo?.Invoke(instance, new object[] { this });
			}
		}
	}
}
