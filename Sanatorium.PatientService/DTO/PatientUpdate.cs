using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatorium.PatientService.DTO
{
	public class PatientUpdate
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateOnly BirthDate { get; set; }
		public string PhoneNumber { get; set; }
	}
}
