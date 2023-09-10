using System.Globalization;
using Astronomy.Resources.Languages;
namespace Astronomy.Data;

public static class SolarSystemData
{
	public static readonly AstronomicalBody Sun = new AstronomicalBody()
	{
		Name = AstronomicalBodies.Sun_Name,
		Mass = $"{1.9855.ToString("0.0000", CultureInfo.CurrentUICulture)}*10^30 kg",
		Circumference = $"{4379000.ToString("0,0", CultureInfo.CurrentUICulture)} km",
		Age = $"{4.57.ToString("0.00", CultureInfo.CurrentUICulture)} {AstronomicalBodies.Billons_Convert.ToLower()} {AstronomicalBodies.Years.ToLower()}",
		EmojiIcon = "☀"
	};

	public static readonly AstronomicalBody Earth = new AstronomicalBody()
	{
		Name = AstronomicalBodies.Earth_Name,
		Mass = $"{5.97237.ToString("0.00000", CultureInfo.CurrentUICulture)}*10^24 kg",
		Circumference = $"{40075.ToString("0,0", CultureInfo.CurrentUICulture)} km",
		Age =
			$"{4.54.ToString("0.00", CultureInfo.CurrentUICulture)} {AstronomicalBodies.Billons_Convert.ToLower()} {AstronomicalBodies.Years.ToLower()}",
		EmojiIcon = "🌍"
	};

	public static readonly AstronomicalBody Moon = new AstronomicalBody()
	{
		Name = AstronomicalBodies.Moon_Name,
		Mass = $"{7.342.ToString("0.000", CultureInfo.CurrentUICulture)} kg",
		Circumference = $"{10921.ToString("0,0", CultureInfo.CurrentUICulture)} km",
		Age =
			$"{4.53.ToString("0.00", CultureInfo.CurrentUICulture)} {AstronomicalBodies.Billons_Convert.ToLower()} {AstronomicalBodies.Years.ToLower()}",
		EmojiIcon = "🌕"
	};

	public static readonly AstronomicalBody HalleyComet = new AstronomicalBody()
	{
		Name = AstronomicalBodies.Halley_Name,
		Mass = "22*10^14",
		Circumference = "11 km",
		Age = $"{4.6.ToString("0.0", CultureInfo.CurrentUICulture)} {AstronomicalBodies.Billons_Convert.ToLower()} {AstronomicalBodies.Years.ToLower()}",
		EmojiIcon = "☄"
	};
}