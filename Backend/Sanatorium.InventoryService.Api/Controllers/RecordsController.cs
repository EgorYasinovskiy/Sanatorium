using Microsoft.AspNetCore.Mvc;

using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItemRecord;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItemRecord;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItemRecord;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordById;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByDateRange;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetRecordsByItem;
using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.Api.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class RecordsController : BaseController
	{
		[HttpGet("{start}/{end}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InventoryRecordListDTO>> GetByDateRange(DateTime start, DateTime end, CancellationToken cancellationToken)
		{
			var command = new GetRecordsByDateRange() { From = start, To = end };
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("byItem/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InventoryRecordListDTO>> GetByItemId(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetRecordsByItem() { ItemId = id };
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "GetRecord")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InventoryRecordDTO>> GetById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetRecordById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create([FromBody] CreateRecordDTO dto)
		{
			var command = new AddItemRecord() { CreateRecordDTO = dto };
			var result = await Mediator.Send(command);
			return result == null ? BadRequest() : CreatedAtRoute("GetRecord", new { id = result.Id }, result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteItemRecord() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update([FromBody] UpdateRecordDTO dto)
		{
			var command = new UpdateItemRecord() { UpdateRecordDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}