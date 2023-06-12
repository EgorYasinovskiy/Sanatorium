using Microsoft.AspNetCore.Mvc;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateInventoryInvoice;
using Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreatePatientInvoice;
using Sanatorium.InvoiceService.BusinessLogic.CQRS.Commands.GetOrCreateStaffInvoice;

namespace Sanatorium.InvoiceService.Api.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class ReportController : BaseController
	{
		[HttpGet("patient/{patientId}/{dateFrom}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InvoiceDTO>> GetPatientInvoice(Guid patientId, DateOnly dateFrom, [FromQuery] bool refreshData, CancellationToken cancellationToken)
		{
			var command = new GetOrCreatePatientInvoice()
			{
				PatientId = patientId,
				DateFrom = dateFrom,
				RefreshData = refreshData
			};
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpGet("staff/{staffId}/{dateFrom}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InvoiceDTO>> GetStaffInvoice(Guid staffId, DateOnly dateFrom, CancellationToken cancellationToken)
		{
			var command = new GetOrCreateStaffInvoice()
			{
				StaffId = staffId,
				DateFrom = dateFrom
			};
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpGet("inventory/{dateFrom}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InvoiceDTO>> GetInventoryInvoice(DateOnly dateFrom, CancellationToken cancellationToken)
		{
			var command = new GetOrCreateInventoryInvoice()
			{
				DateFrom = dateFrom
			};
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}
	}
}
