using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.Update
{
	public class Update : IRequest
	{
		public UpdateStaffDTO UpdateStaffDTO { get; set; }
	}
}
