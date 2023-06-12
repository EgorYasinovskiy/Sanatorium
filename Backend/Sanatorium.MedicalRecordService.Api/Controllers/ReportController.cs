using Microsoft.AspNetCore.Mvc;

using Sanatorium.Common.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetInvoice;

namespace Sanatorium.MedicalRecordService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ReportController : BaseController
	{
		[HttpGet("invoice/{patientId}/{fromDate}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InvoiceDTO>> GetInvoice(Guid patientId, DateOnly fromDate, CancellationToken cancellationToken)
		{
			var command = new GetInvoice() { PatientId = patientId, From = fromDate };
			var result = await Mediator.Send(command, cancellationToken);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
	}
}
