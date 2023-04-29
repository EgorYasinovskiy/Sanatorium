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
			var result = await Mediator.Send(new CQRS.Queries.GetAll.GetAll());
			return Ok(result);
		}


		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PatientList>> Get(Guid id)
		{
			var result = await Mediator.Send(new CQRS.Queries.GetById.GetById() { Id = id});
			if(result == null)
				return NotFound();
			return Ok(result);
		}

	}
}