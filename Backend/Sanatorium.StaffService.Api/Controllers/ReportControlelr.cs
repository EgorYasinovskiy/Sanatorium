using Microsoft.AspNetCore.Mvc;

using Sanatorium.Common.DTO;
using Sanatorium.StaffService.BusinessLogic.CQRS.Queries.GetStaffInvoice;

namespace Sanatorium.StaffService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ReportControlelr : BaseController
	{
		[HttpGet("invoice/{staffId}/{date}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InvoiceDTO>> GetStaffInvoice(Guid staffId, DateOnly date, CancellationToken cancellationTokens)
		{
			var command = new GetStaffInvoice()
			{
				DateFrom = date,
				StaffId = staffId,
			};

			var result = await Mediator.Send(command, cancellationTokens);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
	}
}
