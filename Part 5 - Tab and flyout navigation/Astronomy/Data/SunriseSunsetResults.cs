namespace Astronomy.Data;

// ReSharper disable ClassNeverInstantiated.Global
public class SunriseSunsetResults
// ReSharper restore ClassNeverInstantiated.Global
{
#pragma warning disable 0649
	//Fields are only set via JSON , so disable warning that the fields are never set.
	public string Sunrise { get; set; }
	public string Sunset { get; set; }
#pragma warning restore 0649
}