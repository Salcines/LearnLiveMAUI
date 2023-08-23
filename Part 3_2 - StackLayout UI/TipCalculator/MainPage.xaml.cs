namespace TipCalculator;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BillInput.TextChanged += (s, e) => CalculateTip(false, false);
		RoundDown.Clicked += (s, e) => CalculateTip(true, false);
		RoundUp.Clicked += (s, e) => CalculateTip(false, true);

		TipPercentSlider.ValueChanged += (s, e) =>
		{
			double percentage = Math.Round(e.NewValue);
			TipPercent.Text = $"{percentage}%";
			CalculateTip(false, false);
		};
	}

	private void CalculateTip(bool roundDown, bool roundUp)
	{
		if (Double.TryParse(BillInput.Text, out var netBill) && netBill > 0)
		{
			double percentage = Math.Round(TipPercentSlider.Value);
			double tip = Math.Round(netBill * (percentage / 100), 2);

			double totalBill = netBill + tip;

			if (roundUp)
			{
				totalBill = Math.Ceiling(totalBill);
				tip = totalBill - netBill;
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
		=> TipPercentSlider.Value = 15;
	

	private void OnGenerousTip(object sender, EventArgs e)
		=> TipPercentSlider.Value = 20;
	
}

