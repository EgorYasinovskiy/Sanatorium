using Microsoft.AspNetCore.Mvc;

using Sanatorium.Common.DTO;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetInvoice;

namespace Sanatorium.RoomService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ReportController : BaseController
	{
		[HttpGet("invoice/{patientId}/{fromDate}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InvoiceDTO>> GetInvoice(Guid patientId, DateOnly fromDate, CancellationToken cancellationToken)
		{
			var command = new GetInvoice() { PatientID = patientId, From = fromDate };
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}
	}
}
