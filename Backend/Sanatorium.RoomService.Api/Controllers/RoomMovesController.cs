using Microsoft.AspNetCore.Mvc;

using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoomMove;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoomMove;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoomMove;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMove;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoomMoves;
using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class RoomMovesController : BaseController
	{
		[HttpGet("{start}/{end}/{patientId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RoomMoveList>> Get(DateOnly start, DateOnly end, Guid patientId, CancellationToken cancellationToken)
		{
			var command = new GetRoomMoves() { PatientId = patientId };
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RoomMoveList>> Get(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetRoomMove() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			if (result != null)
				return Ok(result);
			return NotFound();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Create([FromBody] CreateRoomMoveDTO createRoomMoveDTO)
		{
			var command = new CreateRoomMove() { CreateRoomMoveDTO = createRoomMoveDTO };
			var result = await Mediator.Send(command);
			return CreatedAtRoute("Get", new { id = result.Id }, result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteRoomMove() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update([FromBody] UpdateRoomMoveDTO updateRoomMoveDTO)
		{
			var command = new UpdateRoomMove() { UpdateRoomMoveDTO = updateRoomMoveDTO };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
