using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sanatorium.PatientService.DTO;

namespace Sanatorium.PatientService.Controllers
{

	[Produces("application/json")]
	[Route("api/[controller]")]
	public class PatientController : BaseController
	{
		private readonly IMapper _mapper;

		public PatientController(IMapper mapper) =>
			_mapper = mapper;

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<PatientList>> GetAll()
		{
			var query = new CQRS.Queries.GetAll.GetAll();
			var result = await Mediator.Send(query);
			return Ok(result);
		}


		[HttpGet("{id}", Name = "Get")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PatientDTO>> Get(Guid id)
		{
			var query = new CQRS.Queries.GetById.GetById() { Id = id };
			var result = await Mediator.Send(query);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> RegisterNew([FromBody] CreatePatientDTO patient)
		{
			var command = new CQRS.Commands.RegisterNew.RegisterNew() { Patient = patient };
			var result = await Mediator.Send(command);
			return CreatedAtRoute("Get", new { id = result.Id }, result);
		}
		[HttpPut("{id}/register")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Register(Guid id)
		{
			var command = new CQRS.Commands.Register.Register() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("{id}/discharge")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Discharge(Guid id)
		{
			var command = new CQRS.Commands.Discharge.Discharge() { Id = id };
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update([FromBody] PatientUpdate patientDto)
		{
			var command = new CQRS.Commands.Update.Update() { NewPatient = patientDto };
			await Mediator.Send(command);
			return NoContent();
		}
	}
}