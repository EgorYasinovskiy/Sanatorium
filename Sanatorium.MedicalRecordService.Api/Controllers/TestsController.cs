using Microsoft.AspNetCore.Mvc;

using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestReffal;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestResult;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestReffal;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestResult;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestReffal;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestResult;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllTestTypes;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsById;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByPatient;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestResultById;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestTypeById;
using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class TestsController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<TestTypeListDTO>> GetAll(CancellationToken cancellationToken)
		{
			var command = new GetAllTestTypes();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "GetType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<TestTypeDTO>> GetById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetTestTypeById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpGet("reffals/byPatient")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<TestReffalsListDTO>> GetReffalsByPatient([FromBody] GetTestReffalsByPatient command, CancellationToken cancellationToken)
		{
			var result = await Mediator.Send(command, cancellationToken);
			return result.TestReffals.Any() ? Ok(result) : NoContent();
		}

		[HttpGet("reffals/byType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<TestReffalsListDTO>> GetReffalsByType([FromBody] GetTestReffalsByType command, CancellationToken cancellationToken)
		{
			var result = await Mediator.Send(command, cancellationToken);
			return result.TestReffals.Any() ? Ok(result) : NoContent(); ;
		}

		[HttpGet("reffals/{id}", Name = "GetReffal")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<TestReffalsListDTO>> GetReffalById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetTestReffalsById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpGet("results/{id}", Name = "GetResult")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<TestReffalsListDTO>> GetResultById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetTestResultById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddTestType([FromBody] CreateTestTypeDTO dto)
		{
			var command = new AddTestType() { CreateTestType = dto };
			var result = await Mediator.Send(command);
			if (result == null)
				return BadRequest();
			return CreatedAtRoute("GetType", new { id = result.Id }, result);
		}

		[HttpPost("reffals")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddTestReffal([FromBody] CreateTestReffalDTO dto)
		{
			var command = new AddTestReffal() { CreateTestReffalDTO = dto };
			var result = await Mediator.Send(command);
			if (result == null)
				return BadRequest();
			return CreatedAtRoute("GetReffal", new { id = result.Id }, result);
		}

		[HttpPost("results")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddTestResult([FromBody] CreateTestResultDTO dto)
		{
			var command = new AddTestResult() { CreateResult = dto };
			var result = await Mediator.Send(command);
			if (result == null)
				return BadRequest();
			return CreatedAtRoute("GetResult", new { id = result.Id }, result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteTestType(Guid id)
		{
			var command = new DeleteTestType() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("reffals/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteTestReffal(Guid id)
		{
			var command = new DeleteTestReffal() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("results/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteTestResult(Guid id)
		{
			var command = new DeleteTestResult() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> UpdateTestType([FromBody] UpdateTestTypeDTO dto)
		{
			var command = new UpdateTestType() { UpdateTestTypeDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("reffals")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> UpdateTestReffal([FromBody] UpdateTestReffalDTO dto)
		{
			var command = new UpdateTestReffal() { UpdateTestReffalDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("results")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> UpdateTestResult([FromBody] UpdateTestResultDTO dto)
		{
			var command = new UpdateTestResult() { Update = dto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
