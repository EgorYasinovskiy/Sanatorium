using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Sanatorium.MedicalRecordService.Api.Controllers
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