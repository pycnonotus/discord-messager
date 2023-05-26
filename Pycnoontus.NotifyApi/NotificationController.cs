using Microsoft.AspNetCore.Mvc;
using Pycnonotus.Application;

namespace Pycnoontus.NotifyApi;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
	private readonly INotifier _notifier;

	public NotificationController(INotifier notifier)
	{
		_notifier = notifier;
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] Message message)
	{
		await _notifier.NotifyAsync(message);
		return NoContent();
	}

}
