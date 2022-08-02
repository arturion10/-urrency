namespace Currencies.Bll;

public class CurrencyNotFoundException : BusinessException
{
	public CurrencyNotFoundException() : base("Failed to find currency.")
	{
	}
}
