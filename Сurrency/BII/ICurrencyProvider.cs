using Currencies.Models;

namespace Currencies.Bll;

public interface ICurrencyProvider
{
	Task<IEnumerable<Currency>> GetCurrencies(int page, int size, CancellationToken token);

	Task<Currency> GetCurrency(string id, CancellationToken token);
}