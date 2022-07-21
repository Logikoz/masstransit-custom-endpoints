using MassTransit;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TestController : ControllerBase
	{
		[HttpGet]
		[Route("Send/{value}")]
		public async Task<IActionResult> TestAsync(string value, [FromServices] IBus bus)
		{
			await bus.Publish(new ValueEntered { Value = value });

			return Ok();
		}
	}
}