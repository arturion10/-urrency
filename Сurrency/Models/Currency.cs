using System.Text.Json.Serialization;

namespace Currencies.Models;

public class Currency
{
	[JsonPropertyName("ID")]
	public string Id { get; set; }
	public string NumCode { get; set; }
	public string CharCode { get; set; }
	public int Nominal { get; set; }
	public string Name { get; set; }
	public float Value { get; set; }
	public float Previous { get; set; }
}