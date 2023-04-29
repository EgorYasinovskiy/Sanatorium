using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sanatorium.PatientService.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class BaseController : ControllerBase
	{
		private IMediator _mediator;

		protected IMediator Mediator
		{
			get
			{
				return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
			}
		}
	}
}