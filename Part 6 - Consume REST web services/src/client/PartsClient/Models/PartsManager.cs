using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace PartsClient.Models;
public static class PartsManager
{
	//TODO: Add fields for BaseAddress, Url, and authorizationKey
	private static readonly string BaseAddress = "https://mslearnpartsserver1507822133.azurewebsites.net";
	private static readonly string Url = $"{BaseAddress}/api/";

	private static string _authorizationKey;

	private static HttpClient client;

	private static async Task<HttpClient> GetClient()
	{
		if (client != null)
		{
			return client;
		}

		client = new HttpClient();

		if (string.IsNullOrEmpty(_authorizationKey))
		{
			_authorizationKey = await client.GetStringAsync($"{Url}login");
			_authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
		}

		client.DefaultRequestHeaders.Add("Authorization",_authorizationKey);
		client.DefaultRequestHeaders.Add("Accept", "application/json");

		return client;
	}

	public static async Task<IEnumerable<Part>> GetAll()
	{
		if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
		{
			return new List<Part>();
		}

		HttpClient client = await GetClient();

		string result = await client.GetStringAsync($"{Url}parts");

		return JsonConvert.DeserializeObject<List<Part>>(result);
	}

	public static async Task<Part> Add(string partName, string supplier, string partType)
	{
		if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
		{
			return new Part();
		}

		Part part = new Part()
		{
			PartId = string.Empty,
			PartName = partName,
			Suppliers = new List<string>(new[] { supplier }),
			PartType = partType,
			PartAvailableData = DateTime.Now.Date
		};

		HttpClient client = await GetClient();

		var message = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");

		message.Content = JsonContent.Create<Part>(part);

		var payload = await client.SendAsync(message);
		payload.EnsureSuccessStatusCode();

		var response = await payload.Content.ReadAsStringAsync();

		var insertedPart = JsonConvert.DeserializeObject<Part>(response);

		return insertedPart;

	}

	public static async Task Update(Part part)
	{
		if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
		{
			return;
		}

		HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, $"{Url}parts/{part.PartId}");
		message.Content = JsonContent.Create<Part>(part);

		HttpClient client = await GetClient();

		var payload = await client.SendAsync(message);
		payload.EnsureSuccessStatusCode();
	}

	public static async Task Delete(string partId)
	{
		if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
		{
			return;
		}

		HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, $"{Url}parts/{partId}");

		HttpClient client = await GetClient();

		var payload = await client.SendAsync(message);

		payload.EnsureSuccessStatusCode();
	}
}