using System.Text.Json;

namespace Astronomy.Data;

public class SunriseService
{
	private const string SunriseSunsetServiceUri = "https://api.sunrise-sunset.org";

	public async Task<(DateTime Sunrise, DateTime Sunset)> GetSunriseSunsetTimes(double latitude, double longitude)
	{
		var query = $"{SunriseSunsetServiceUri}/json?lat={latitude}&lng={longitude}&date=today";

		var client = new HttpClient();
		client.DefaultRequestHeaders.Add("Accept", "application/json");
		var json = await client.GetStringAsync(query);

		var options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
		//var data = JsonSerializer.Deserialize<SunriseSunsetData(json, options);
		var data = JsonSerializer.Deserialize<SunriseSunsetData>(json, options);

		return (DateTime.Parse(data.Results.Sunrise), DateTime.Parse(data.Results.Sunset));
	}
}
