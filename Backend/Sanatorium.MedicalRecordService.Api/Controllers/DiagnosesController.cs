using Microsoft.AspNetCore.Mvc;

using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddPatientDiagnosis;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeletePatientDiagnosis;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdatePatientDiagnosis;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllDiagnosis;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllPacientDiagnosis;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetDiagnosisById;
using Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetPacientDiagnosisById;
using Sanatorium.MedicalRecordService.BusinessLogic.DTO;

namespace Sanatorium.MedicalRecordService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class DiagnosesController : BaseController
	{
		[HttpGet("/all")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<DiagnosisListDTO>> Get(CancellationToken cancellationToken)
		{
			var query = new GetAllDiagnosis();
			var result = Mediator.Send(query, cancellationToken);
			return Ok(result);
		}

		[HttpGet("/all/{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<DiagnosisDTO>> Get(Guid id, CancellationToken cancellationToken)
		{
			var query = new GetDiagnosisById() { Id = id };
			var result = await Mediator.Send(query, cancellationToken);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpGet("/patient/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PatientDiagnosisListDTO>> GetPatientDiagnosis(Guid id, CancellationToken cancellationToken)
		{
			var query = new GetAllPacientDiagnosis() { PatientId = id };
			var result = await Mediator.Send(query, cancellationToken);
			if (result.Diagnoses.Any())
				return Ok(result);
			return NotFound();
		}

		[HttpGet("{id}", Name = "GetPatients")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PatientDiagnosisListDTO>> GetPatientDiagnosisById(Guid id, CancellationToken cancellationToken)
		{
			var query = new GetPacientDiagnosisById() { Id = id };
			var result = await Mediator.Send(query, cancellationToken);
			if (result != null)
				return Ok(result);
			return NotFound();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddPatientDiagnosis([FromBody] CreatePatientDiagnosisDTO dto)
		{
			var command = new AddPatientDiagnosis() { CreatePatientDiagnosisDTO = dto };
			var result = await Mediator.Send(command);

			if (result != null)
				return CreatedAtRoute("GetPatients", new { patientDiagnosisId = result.Id }, result);
			else
				return BadRequest();
		}

		[HttpDelete("/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteDiagnosis(Guid id)
		{
			var command = new DeletePatientDiagnosis() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update([FromBody] UpdatePatientDiagnosisDTO dto)
		{
			var command = new UpdatePatientDiagnosis() { UpdatePatientDiagnosisDTO = dto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
