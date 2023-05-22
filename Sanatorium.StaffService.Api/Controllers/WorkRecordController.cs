using Microsoft.AspNetCore.Mvc;

using Sanatorium.StaffService.BusinessLogic.DTO;

namespace Sanatorium.StaffService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class WorkRecordController : BaseController
	{
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<StaffWorkRecordsDTO>> Get(Guid id)
		{
			var query = new BusinessLogic.CQRS.Queries.GetStaffWorkRecords.GetStaffWorkRecords()
			{
				StaffId = id
			};
			var result = await Mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Create([FromBody] BusinessLogic.CQRS.Commands.AddWorkTime.AddWorkTime command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Update([FromBody] BusinessLogic.CQRS.Commands.UpdateWorkTime.UpdateWorkTime command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id")]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new BusinessLogic.CQRS.Commands.DeleteWorkTime.DeleteWorktime()
			{
				RecordId = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
