using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronomy.Data
{
	public static class MoonPhaseCalculator
    {
	    public enum Phase
	    {
		    New,
			WaxingCrescent,
			FirstQuarter,
			WaxingGibbous,
			Full,
			WaningGibbous,
			ThirdQuarter,
			WaningCrescent
	    }

	    private const double SynodicLength = 29.530588853;
	    private static readonly DateTime ReferenceNewMoonDate = new DateTime(2017, 11, 18);

	    public static Phase GetPhase(DateTime date)
	    {
		    return GetPhase(GetAge(date));
	    }

	    private static double GetAge(DateTime date)
	    {
		    double days = (date - ReferenceNewMoonDate).TotalDays;

			return days % SynodicLength;
	    }

	    static Phase GetPhase(double age)
	    {
		    return age switch
		    {
			    < 1 => Phase.New,
			    < 7 => Phase.WaxingCrescent,
			    < 8 => Phase.FirstQuarter,
			    < 14 => Phase.WaxingGibbous,
				< 15 => Phase.Full,
				< 22 => Phase.WaningGibbous,
				< 23 => Phase.ThirdQuarter,
				< 29 => Phase.WaningCrescent,
			    _ => Phase.New
		    };
	    }
    }
}
