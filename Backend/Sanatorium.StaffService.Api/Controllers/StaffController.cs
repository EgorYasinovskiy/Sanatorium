using Microsoft.AspNetCore.Mvc;

using Sanatorium.StaffService.BusinessLogic.DTO;
using Sanatorium.StaffService.BusinessLogic.Models;

namespace Sanatorium.StaffService.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : BaseController
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<StaffList>> GetAllStaff()
		{
			var query = new BusinessLogic.CQRS.Queries.GetAllStaff.GetAllStaff();
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{id}", Name = "GetStaff")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<StaffDTO>> GetStaff(Guid id)
		{
			var query = new BusinessLogic.CQRS.Queries.GetStaffById.GetStaffById();
			query.StaffId = id;
			var result = await Mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		[HttpGet("{id}/payments/{periodStart}/{periodEnd}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PaymentInfo>> GetPayemnts(Guid id, DateOnly periodStart, DateOnly periodEnd)
		{
			var query = new BusinessLogic.CQRS.Queries.CalculatePayment.CalculatePayment()
			{
				StaffId = id,
				PeriodStart = periodStart,
				PeriodEnd = periodEnd
			};
			var result = await Mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		[HttpGet("payments/{periodStart}/{periodEnd}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PaymentShortInfo>> GetAllPayments(DateOnly periodStart, DateOnly periodEnd)
		{
			var query = new BusinessLogic.CQRS.Queries.CalculatePaymentsForAll.CalculatePaymentsForAll()
			{
				PeriodStart = periodStart,
				PeriodEnd = periodEnd
			};
			var result = await Mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		[HttpPut("manager")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> ChangeManager([FromBody] BusinessLogic.CQRS.Commands.ChangeManager.ChangeManager command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("position")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> ChangePosition([FromBody] BusinessLogic.CQRS.Commands.ChangePosition.ChangePosition command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("salary")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> ChangeSalary([FromBody] BusinessLogic.CQRS.Commands.ChangeSalary.ChangeSalary command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("schedule")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> ChangeSchedule([FromBody] BusinessLogic.CQRS.Commands.ChangeSchedule.ChangeSchedule command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut("cabinet")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> ChangeCabinet([FromBody] BusinessLogic.CQRS.Commands.ChangeCabinet.ChangeCabinet command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut()]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Update([FromBody] UpdateStaffDTO updateDto)
		{
			var command = new BusinessLogic.CQRS.Commands.Update.Update()
			{
				UpdateStaffDTO = updateDto
			};
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new BusinessLogic.CQRS.Commands.Delete.Delete()
			{
				StaffId = id
			};
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<StaffDTO>> Create([FromBody] CreateStaffDTO staffDto)
		{
			var command = new BusinessLogic.CQRS.Commands.RegisterNew.RegisterNew()
			{
				CreateStaffDTO = staffDto
			};
			var result = await Mediator.Send(command);
			return CreatedAtRoute("GetStaff", new {id = result.Id },result);
		}

	}
}
