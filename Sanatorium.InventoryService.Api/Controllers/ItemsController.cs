using Microsoft.AspNetCore.Mvc;

using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.AddItem;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.DeleteItem;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Commands.UpdateItem;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryList;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryResume;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetItemById;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetMissingItems;
using Sanatorium.InventoryService.BusinessLogic.DTO;

namespace Sanatorium.InventoryService.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[Produces("application/json")]
	public class ItemsController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InventoryItemListDTO>> GetAll(CancellationToken cancellationToken)
		{
			var command = new GetInventoryList();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<InventoryItemDTO>> GetById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetItemById() { Id = id };
			var result = Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpGet("resume")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InventoryResumeDTO>> GetResume(CancellationToken cancellationToken)
		{
			var command = new GetInventoryResume();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("missing")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<InventoryItemListDTO>> GetMissing(CancellationToken cancellationToken)
		{
			var command = new GetMissingItems();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create([FromBody] CreateItemDTO dto)
		{
			var command = new AddItem() { CreateItemDTO = dto };
			var result = await Mediator.Send(command);
			if (result != null)
				return CreatedAtRoute("Get", new { id = result.Id }, result);
			return BadRequest();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteItem() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update([FromBody] UpdateItemDTO dto)
		{
			var command = new UpdateItem() { UpdateItemDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
