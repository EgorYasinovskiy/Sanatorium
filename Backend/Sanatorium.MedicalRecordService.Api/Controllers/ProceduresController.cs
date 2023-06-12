using Microsoft.AspNetCore.Mvc;

using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureReffal;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllProcedureTypes;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByPatient;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByType;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureRefflalById;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureTypeById;
using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ProceduresController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ProcedureTypesListDTO>> GetAllTypes(CancellationToken cancellationToken)
		{
			var command = new GetAllProcedureTypes();
			var result = await Mediator.Send(command, cancellationToken);
			return Ok(result);
		}

		[HttpGet("reffals/byType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<ProcedureReffalsListDTO>> GetReffalsByType([FromBody] GetProcedureReffalsByType command, CancellationToken cancellationToken)
		{
			var result = await Mediator.Send(command, cancellationToken);
			return result.ProcedureReffals.Any() ? Ok(result) : NoContent();
		}

		[HttpGet("reffals/byPatient")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<ProcedureReffalsListDTO>> GetReffalsByPatient([FromBody] GetProcedureReffalsByPatient command, CancellationToken cancellationToken)
		{
			var result = await Mediator.Send(command, cancellationToken);
			return result.ProcedureReffals.Any() ? Ok(result) : NoContent();
		}

		[HttpGet("{id}", Name = "GetType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProcedureTypeDTO>> GetTypeById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetProcedureTypeById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpGet("reffals/{id}", Name = "GetReffal")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProcedureReffalDTO>> GetReffalById(Guid id, CancellationToken cancellationToken)
		{
			var command = new GetProcedureRefflalById() { Id = id };
			var result = await Mediator.Send(command, cancellationToken);
			return result == null ? NotFound() : Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddReffal([FromBody] CreateProceduralReffalDTO dto)
		{
			var command = new AddProcedureReffal() { CreateProceduralReffalDTO = dto };
			var result = await Mediator.Send(command);
			return result == null ? BadRequest() : CreatedAtRoute("GetReffal", new { id = result.Id }, result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddType([FromBody] CreateProcedureTypeDTO dto)
		{
			var command = new AddProcedureType() { CreateProcedureTypeDTO = dto };
			var result = await Mediator.Send(command);
			return result == null ? BadRequest() : CreatedAtRoute("GetType", new { id = result.Id }, result);
		}
	}
}
