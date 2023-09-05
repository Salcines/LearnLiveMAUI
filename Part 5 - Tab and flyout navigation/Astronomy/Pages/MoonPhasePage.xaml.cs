using Astronomy.Data;
using Astronomy.Resources.Languages;

namespace Astronomy.Pages;

public partial class MoonPhasePage : ContentPage
{
	public MoonPhasePage()
	{
		InitializeComponent();

		InitializeUi();
	}

	private void InitializeUi()
	{
		var phase = MoonPhaseCalculator.GetPhase(DateTime.Now);
		var culture = Thread.CurrentThread.CurrentUICulture;

		DateLabel.Text = DateTime.Today.ToString("D");
		MoonPhaseIconLabel.Text = MoonPhaseEmojis[phase];
		MoonPhaseTextLabel.Text = MoonPhaseName.ResourceManager.GetString(phase.ToString(), culture);



		//MoonPhaseTextLabel.Text = PhaseLocalization(phase.ToString());

		SetMoonPhaseLabels(PhaseIcon1Label, PhaseText1Label, 1, culture);
		SetMoonPhaseLabels(PhaseIcon2Label, PhaseText2Label, 2, culture);
		SetMoonPhaseLabels(PhaseIcon3Label, PhaseText3Label, 3, culture);
		SetMoonPhaseLabels(PhaseIcon4Label, PhaseText4Label, 4, culture);
	}
	private void SetMoonPhaseLabels(Label labelIcon, Label labelText, int dayOffset, System.Globalization.CultureInfo culture)
	{
		var phase = MoonPhaseCalculator.GetPhase(DateTime.Now.AddDays(dayOffset));
		labelIcon.Text = MoonPhaseEmojis[phase];
		labelText.Text = DaysOfWeek.ResourceManager.GetString(DateTime.Now.AddDays(dayOffset).DayOfWeek.ToString(), culture);
	}

	private static readonly Dictionary<MoonPhaseCalculator.Phase, string> MoonPhaseEmojis =
		new Dictionary<MoonPhaseCalculator.Phase, string>()
		{
			{ MoonPhaseCalculator.Phase.New, "🌑" },
			{ MoonPhaseCalculator.Phase.WaxingCrescent, "🌒" },
			{ MoonPhaseCalculator.Phase.FirstQuarter, "🌓" },
			{ MoonPhaseCalculator.Phase.WaxingGibbous, "🌔" },
			{ MoonPhaseCalculator.Phase.Full, "🌕" },
			{ MoonPhaseCalculator.Phase.WaningGibbous, "🌖" },
			{ MoonPhaseCalculator.Phase.ThirdQuarter, "🌗" },
			{ MoonPhaseCalculator.Phase.WaningCrescent, "🌘" }
		};
}