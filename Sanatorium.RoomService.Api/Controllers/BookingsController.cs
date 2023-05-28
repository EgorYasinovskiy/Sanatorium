using Microsoft.AspNetCore.Mvc;

using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.CreateBooking;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.DeleteBooking;
using Sanatorium.RoomService.BusinessLogic.CQRS.Commands.UpdateBooking;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetAllBookings;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBooking;
using Sanatorium.RoomService.BusinessLogic.CQRS.Queries.GetBookings;
using Sanatorium.RoomService.BusinessLogic.DTO;

namespace Sanatorium.RoomService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class BookingsController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<BookingList>> GetAll(CancellationToken cancellationToken)
		{
			var request = new GetAllBookings();
			var response = await Mediator.Send(request, cancellationToken);
			return Ok(response);
		}

		[HttpGet("actual")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<BookingList>> GetActual(CancellationToken cancellationToken)
		{
			var request = new GetBookings();
			var response = await Mediator.Send(request, cancellationToken);
			return Ok(response);
		}

		[HttpGet("{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BookingDTO>> GetById(Guid id, CancellationToken cancellationToken)
		{
			var request = new GetBooking() { Id = id };
			var response = await Mediator.Send(request, cancellationToken);
			if (response == null)
				return NotFound();
			return Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateNew([FromBody] CreateBookingDTO createBookingDTO)
		{
			var command = new CreateBooking() { CreateBookingDTO = createBookingDTO };
			var booking = await Mediator.Send(command);
			return CreatedAtRoute("Get", new { id = booking.Id }, booking);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteBooking() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update([FromBody] UpdateBookingDTO updateBookingDTO)
		{
			var command = new UpdateBooking() { UpdateBookingDTO= updateBookingDTO };
			await Mediator.Send(command);
			return NoContent();

	}
}
