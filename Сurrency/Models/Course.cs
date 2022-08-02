using System.Text.Json.Serialization;

namespace Currencies.Models;

internal class Course
{
	public DateTime Date { get; set; }
	public DateTime PreviousDate { get; set; }
	[JsonPropertyName("PreviousURL")]
	public string PreviousUrl { get; set; }
	public DateTime Timestamp { get; set; }
	public Dictionary<string, Currency>? Valute { get; set; }
}
