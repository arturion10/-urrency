namespace Currencies.Bll;

public class ErrorGettingDataException : Exception
{
	public ErrorGettingDataException() : base("Failed to get data from currency API.")
	{
	}
}
