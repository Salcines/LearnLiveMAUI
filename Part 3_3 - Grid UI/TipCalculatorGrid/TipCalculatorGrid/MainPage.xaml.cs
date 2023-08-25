namespace TipCalculatorGrid;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BillInput.TextChanged += (s, e)
			=> CalculateTip(false, false);
		RoundDown.Clicked +=(sender, e)
			=> CalculateTip(true, false);
		RoundUp.Clicked += (s, e)
			=> CalculateTip(false, true);

		TipPercentageSlider.ValueChanged += (s, e) =>
		{
			double percentage = Math.Round(e.NewValue);
			TipPercentage.Text = $"{percentage}%";
		};
	}

	private void CalculateTip(bool roundDown, bool roundUp)
	{

	}

	private void OnNormalTip(object sender, EventArgs e)
	=> TipPercentageSlider.Value = 15;

	private void OnGenerousTip(object sender, EventArgs e)
		=> TipPercentageSlider.Value = 20;

}

