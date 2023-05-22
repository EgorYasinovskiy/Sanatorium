using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Sanatorium.StaffService.BusinessLogic.CQRS.Commands.DeleteWorkTime
{
	public class DeleteWorktime : IRequest
	{
		public Guid RecordId { get; set; }
	}
}
