namespace Astronomy.Data;

// ReSharper disable ClassNeverInstantiated.Global
public class SunriseSunsetData
// ReSharper restore ClassNeverInstantiated.Global
{
#pragma warning disable 0649
	//Field is only set via JSON deserialization, so disable warning that the field is never set.
	public SunriseSunsetResults Results { get; set; }
#pragma warning restore 0649
}