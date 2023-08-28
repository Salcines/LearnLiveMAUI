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
			CalculateTip(false, false);
		};
	}

	private void CalculateTip(bool roundDown, bool roundUp)
	{
		if (Double.TryParse(BillInput.Text, out double netBill) && netBill > 0)
		{
			double percentage = Math.Round(TipPercentageSlider.Value);
			double tip = Math.Round(netBill * (percentage / 100.0), 2);

			double totalBill = netBill + tip;

			if (roundUp)
			{
				totalBill = Math.Ceiling(totalBill);
			}
			else if (roundDown)
			{
				totalBill = Math.Floor(totalBill);
				tip = totalBill - netBill;
			}

			TipOutput.Text = tip.ToString("C");
			TotalOutput.Text = totalBill.ToString("C");
		}
	}

	private void OnNormalTip(object sender, EventArgs e)
	=> TipPercentageSlider.Value = 15;

	private void OnGenerousTip(object sender, EventArgs e)
		=> TipPercentageSlider.Value = 20;

}

