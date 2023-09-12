namespace PartsServer.Models;

public class PartFactory
{
	private static readonly object Locker = new();
	public static Dictionary<string, Tuple<DateTime, List<Part>>> Parts = new();

	public static void Initialize(string authorizationToken)
	{
		lock (Locker)
		{
			Parts.Add(authorizationToken, 
				Tuple.Create(DateTime.UtcNow.AddHours(1), DefaultParts.ToList()));
		}
	}

	private static IEnumerable<Part> DefaultParts
	{
		get
		{
			yield return new Part
			{
				PartID = "0545685192",
				PartName = "Large motherboard",
				Suppliers = new List<string> { "A. Datum Corporation", "Allure Boys Corp", "Awesome Computers" },
				PartAvailableDate = new DateTime(2019, 07, 13),
				PartType = "Circuit Board"
			};

			yield return new Part
			{
				PartID = "0553801473",
				PartName = "RISC processor",
				Suppliers = new List<string> { "Allure Boys Corp", "Contoso Ltd", "Parnell Aerospace" },
				PartAvailableDate = new DateTime(2022, 07, 12),
				PartType = "CPU"
			};

			yield return new Part
			{
				PartID = "0544272994",
				PartName = "CISC processor",
				Suppliers = new List<string> { "Fabrikam, Inc", "A. Datum Corporation", "Parnell Aerospace" },
				PartAvailableDate = new DateTime(2020, 9, 4),
				PartType = "CPU"
			};

			yield return new Part
			{
				PartID = "141971189X",
				PartName = "High resolution card",
				Suppliers = new List<string> { "Awesome Computers" },
				PartAvailableDate = new DateTime(2019, 11, 10),
				PartType = "Graphics Card"
			};

			yield return new Part
			{
				PartID = "1256324778",
				PartName = "240V/110V switchable",
				Suppliers = new List<string> { "Reskit" },
				PartAvailableDate = new DateTime(2021, 10, 21),
				PartType = "PSU"
			};
		}
	}

	public static void ClearStaleDate()
	{
		lock (Locker)
		{
			var keys = Parts.Keys.ToList();
			foreach (var oneKey in keys)
			{
				if (Parts.TryGetValue(oneKey, out Tuple<DateTime, List<Part>> result) &&
				    result.Item1 < DateTime.UtcNow)
				{
					Parts.Remove(oneKey);
				}
			}
		}
	}

	private static readonly Random Randomize = new();

	public static string CreatePartId()
	{
		char[] chars = new char[10];

		for (int i = 0; i < 10; i++)
		{
			chars[i] = (char)('0' + Randomize.Next(0, 9));
		}

		return new string(chars);
	}
}
