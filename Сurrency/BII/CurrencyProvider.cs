using Currencies.Models;

namespace Currencies.Bll;

public class CurrencyProvider : ICurrencyProvider
{
	private readonly ILogger<CurrencyProvider> _logger;
	private readonly HttpClient _client;

	public CurrencyProvider(ILogger<CurrencyProvider> logger, HttpClient client)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_client = client ?? throw new ArgumentNullException(nameof(client));
	}

	private async Task<Dictionary<string, Currency>> LoadData(CancellationToken token)
	{
		Course? data;
		try
		{
			data = await _client.GetFromJsonAsync<Course>(@"daily_json.js", cancellationToken: token);
		}
		catch (Exception e)
		{
			_logger.LogError(e.Message, e);
			throw new ErrorGettingDataException();
		}

		if (data?.Valute?.Any() != true)
			return new Dictionary<string, Currency>();

		return data.Valute.ToDictionary(x => x.Value.Id, x => x.Value);
	}

	public async Task<IEnumerable<Currency>> GetCurrencies(int page, int size, CancellationToken token)
	{
		var data = await LoadData(token);
		var result = data.Values
			.Skip((page - 1) * size)
			.Take(size);

		return result;
	}

	public async Task<Currency> GetCurrency(string id, CancellationToken token)
	{
		var data = await LoadData(token);
		if (!data.TryGetValue(id, out var value))
			throw new CurrencyNotFoundException();

		return value;
	}
}
