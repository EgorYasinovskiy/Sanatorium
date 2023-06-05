using Microsoft.AspNetCore.Mvc;

using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetInventoryList;
using Sanatorium.InventoryService.BusinessLogic.CQRS.Queries.GetItemById;
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
	}
}
