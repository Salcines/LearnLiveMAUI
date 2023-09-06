namespace Astronomy.Data;

public interface ILatLogService
{
	Task<(double Latitude, double Longitude)> GetLatLong();
}
