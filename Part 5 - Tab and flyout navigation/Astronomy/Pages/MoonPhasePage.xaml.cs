using Astronomy.Data;

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

		DateLabel.Text = DateTime.Today.ToString("D");
		MoonPhaseIconLabel.Text = MoonPhaseEmojis[phase];
		MoonPhaseTextLabel.Text = phase.ToString();

		SetMoonPhaseLabels(PhaseIcon1Label, PhaseText1Label, 1);
		SetMoonPhaseLabels(PhaseIcon2Label, PhaseText2Label, 2);
		SetMoonPhaseLabels(PhaseIcon3Label, PhaseText3Label, 3);
		SetMoonPhaseLabels(PhaseIcon4Label, PhaseText4Label, 4);
	}

	private void SetMoonPhaseLabels(Label labelIcon, Label labelText, int dayOffset)
	{
		var phase = MoonPhaseCalculator.GetPhase(DateTime.Now.AddDays(dayOffset));
		labelIcon.Text = MoonPhaseEmojis[phase];
		labelText.Text = DateTime.Now.AddDays(dayOffset).DayOfWeek.ToString();
	}

	private static readonly Dictionary<MoonPhaseCalculator.Phase, string> MoonPhaseEmojis =
		new Dictionary<MoonPhaseCalculator.Phase, string>()
		{
			{ MoonPhaseCalculator.Phase.New, "🌑" },
			{ MoonPhaseCalculator.Phase.WaningCrescent, "🌒" },
			{ MoonPhaseCalculator.Phase.FirstQuarter, "🌓" },
			{ MoonPhaseCalculator.Phase.WaxingGibbous, "🌔" },
			{ MoonPhaseCalculator.Phase.Full, "🌕" },
			{ MoonPhaseCalculator.Phase.WaningGibbous, "🌖" },
			{ MoonPhaseCalculator.Phase.LastQuarter, "🌗" },
			{ MoonPhaseCalculator.Phase.WaningCrescent, "🌘" }
		};
}