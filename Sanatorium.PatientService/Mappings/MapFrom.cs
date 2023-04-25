using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace Sanatorium.PatientService.Mappings
{
	public interface MapFrom<T> where T : class
	{
		public void CreateMapping(Profile profile) =>
			profile.CreateMap(typeof(T), GetType());
	}
}
