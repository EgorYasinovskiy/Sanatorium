using Microsoft.AspNetCore.Mvc;

using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateRoom;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteRoom;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateRoom;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllRooms;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetFreeRooms;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetRoom;
using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class RoomsController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RoomListDTO>> Get(CancellationToken cancellationToken)
		{
			var command = new GetAllRooms();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("free")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RoomListDTO>> GetFree(CancellationToken cancellationToken)
		{
			var command = new GetFreeRooms();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<RoomListDTO>> Get(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetRoom() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			if (result != null)
				return Ok(result);
			return NotFound();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create([FromBody] CreateRoomDTO dto)
		{
			var command = new CreateRoom() { CreateRoomDTO = dto };
			var result = await Mediator.Send(command);
			return CreatedAtRoute("Get", new { id = result.Id }, result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteRoom() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update([FromBody] UpdateRoomDTO dto)
		{
			var command = new UpdateRoom() { UpdateRoomDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
