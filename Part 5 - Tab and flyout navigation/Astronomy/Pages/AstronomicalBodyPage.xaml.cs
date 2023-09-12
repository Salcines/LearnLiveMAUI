using Astronomy.Data;

namespace Astronomy.Pages;

[QueryProperty(nameof(AstronomicName), "astronomicName")]
public partial class AstronomicalBodyPage : ContentPage
{
	private string _astronomicName;

	public string AstronomicName
	{
		get => _astronomicName;
		set
		{
			_astronomicName = value;
			UpdateAstronomicBodyUi(_astronomicName);
		}
	}

	public AstronomicalBodyPage()
	{
		InitializeComponent();

		UpdateAstronomicBodyUi("earth");
	}

	private void UpdateAstronomicBodyUi(string astronomicName)
	{
		AstronomicalBody body = FindAstronomicData(astronomicName);

		Title = body.Name;

		IconLabel.Text = body.EmojiIcon;
		NameLabel.Text = body.Name;
		MassLabel.Text = body.Mass;
		CircumferenceLabel.Text = body.Circumference;
		AgeLabel.Text = body.Age;
	}

	private AstronomicalBody FindAstronomicData(string astronomicalBodyName)
	{
		return astronomicalBodyName switch
		{
			"sun" => SolarSystemData.Sun,
			"earth" => SolarSystemData.Earth,
			"moon" => SolarSystemData.Moon,
			"comet" => SolarSystemData.HalleyComet,
			_ => throw new ArgumentException()

		};
	}
}