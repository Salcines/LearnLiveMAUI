using System.Text;

namespace Core;

public static class PhonewordTranslator
{
	private static readonly string[] digits =
	{
		"ABC",
		"DEF",
		"GHI",
		"JKL",
		"MNO",
		"PQRS",
		"TUV",
		"WXYZ"
	};

	public static string ToNumber(string raw)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return null;
		}

		raw = raw.ToUpperInvariant();

		var callNumber = new StringBuilder();

		foreach (var numbers in raw)
		{
			if ("-0123456789".Contains(numbers))
			{
				callNumber.Append(numbers);
			}
			else
			{
				var result = TranslateToNumbers(numbers);
				if (result != null)
				{
					callNumber.Append(result);
				}
				else
				{
					return null;
				}
			}
		}

		return callNumber.ToString();
	}

	private static int? TranslateToNumbers(char numbers)
	{
		for (int i = 0; i < digits.Length; i++)
		{
			if (digits[i].Contains(numbers))
			{
				return i + 2;
			}
		}

		return null;
	}

	private static bool Contains(this string keyString, char valueChar)
	{
		return keyString.IndexOf(valueChar) >= 0;
	}
}
