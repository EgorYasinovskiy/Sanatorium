using Microsoft.AspNetCore.Mvc;

using Sanatorium.Common.DTO;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInvoice;

namespace Sanatorium.InventoryService.Api.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class ReportController : BaseController
	{
		[HttpGet("invoice")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InvoiceDTO>> GetInvoice(CancellationToken cancellationToken)
		{
			var command = new GetInvoice();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

	}
}
