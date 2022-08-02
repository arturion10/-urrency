using Currencies.Bll;
using Currencies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Controllers;

[ApiController]
[Route("/")]
public class DayCourseController : ControllerBase
{
	private readonly ILogger<DayCourseController> _logger;
	private readonly ICurrencyProvider _provider;

	public DayCourseController(ILogger<DayCourseController> logger, ICurrencyProvider provider)
	{
		_logger = logger;
		_provider = provider ?? throw new ArgumentNullException(nameof(provider));
	}

	[HttpGet("currencies")]
	public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies(int page, int size, CancellationToken token)
	{
		try
		{
			var result = await _provider.GetCurrencies(page, size, token);
			return Ok(result);
		}
		catch (Exception e)
		{
			_logger.LogError(e.Message, e);
			throw;
		}
	}

	[HttpGet("currency")]
	public async Task<ActionResult<Currency>> GetCurrency(string id, CancellationToken token)
	{
		try
		{
			var result = await _provider.GetCurrency(id, token);
			return Ok(result);
		}
		catch (BusinessException e)
		{
			_logger.LogWarning(e.Message, e);
			return BadRequest(e.Message);
		}
		catch (Exception e)
		{
			_logger.LogError(e.Message, e);
			throw;
		}
	}
}