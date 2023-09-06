namespace Astronomy.Data;

public class LatLongService : ILatLogService
{
	public async Task<(double Latitude, double Logitude)> GetLatLong()
	{
		var latitudeLocation = 0.0;
		var longitudeLocation = 0.0;

		var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
		if (status == PermissionStatus.Granted)
		{
			var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
			var location = await Geolocation.GetLocationAsync(request);
			latitudeLocation = location!.Latitude;
			longitudeLocation = location.Longitude;
		}

		return (latitudeLocation, longitudeLocation);
	}
}
