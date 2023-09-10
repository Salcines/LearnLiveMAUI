namespace Astronomy.Pages;

public partial class AstronomicalBodiesPage : ContentPage
{
	public AstronomicalBodiesPage()
	{
		InitializeComponent();

		CometButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("astronomicalDetails?astronomicName=comet");
		EarthButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("astronomicalDetails?astronomicName=earth");
		MoonButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("astronomicalDetails?astronomicName=moon");
		SunButton.Clicked += async (s, e) => await Shell.Current.GoToAsync("astronomicalDetails?astronomicName=sun");
	}
}