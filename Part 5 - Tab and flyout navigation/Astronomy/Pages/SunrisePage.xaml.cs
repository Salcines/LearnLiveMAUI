using Astronomy.Data;

namespace Astronomy.Pages;

public partial class SunrisePage : ContentPage
{
	private ILatLogService LatLogService { get; set; }

	public SunrisePage()
	{
		InitializeComponent();
		LatLogService = new LatLongService();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		ActivityWaiting.IsRunning = true;
		var sunriseSunsetData = await GetSunriseSunsetData();
		InitializeUi(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
		ActivityWaiting.IsRunning = false;
	}

	private async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
	{
		var latLongData = await LatLogService.GetLatLong();
		var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

		var riseTime = sunData.Sunrise.ToLocalTime();
		var setTime = sunData.Sunset.ToLocalTime();
		var span = setTime.TimeOfDay - riseTime.TimeOfDay;

		return(riseTime, setTime, span);
	}

	private void InitializeUi(DateTime riseTime, DateTime setTime, TimeSpan span)
	{
		DateLabel.Text = DateTime.Today.ToString("D");
		SunriseLabel.Text = riseTime.ToString("HH:mm:ss");
		DaylightLabel.Text =
			$"{span.Hours} {(Astronomy.Resources.Languages.Sunrise.Hours).ToLower()}, {span.Minutes} {Astronomy.Resources.Languages.Sunrise.Minutes.ToLower()}";
		SunsetLabel.Text = setTime.ToString("HH:mm:ss");
	}
}