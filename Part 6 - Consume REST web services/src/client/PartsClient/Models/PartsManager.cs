namespace PartsClient.Models;
public static class PartsManager
{
	//TODO: Add fields for BaseAddress, Url, and authorizationKey
	private static readonly string BaseAddress = "URL GOES HERE";
	private static readonly string Uri = $"{BaseAddress}/api/";

	private static HttpClient client;

	private static async Task<HttpClient> GetClient()
	{
		throw new NotImplementedException();
	}

	public static async Task<IEnumerable<Part>> GetAll()
	{
		throw new NotImplementedException();
	}

	public static async Task<Part> Add(string partName, string supplier, string partType)
	{
		throw new NotImplementedException();
	}

	public static async Task Update(Part part)
	{
		throw new NotImplementedException();
	}

	public static async Task Delete(string partId)
	{
		throw new NotImplementedException();
	}
}