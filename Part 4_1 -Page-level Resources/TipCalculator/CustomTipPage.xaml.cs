namespace TipCalculator;

public partial class CustomTipPage : ContentPage
{
	public CustomTipPage()
	{
		InitializeComponent();

		BillInput.TextChanged += (s, e)
			=> CalculateTip(false, false);
		RoundUp.Clicked += (s, e)
			=> CalculateTip(true, false);
		RoundDown.Clicked += (s, e)
			=> CalculateTip(false, true);

		TipPercentageSlider.ValueChanged += (s, e) =>
		{
			double percentage = Math.Round(e.NewValue);
			TipPercentage.Text = $"{percentage}%";
			CalculateTip(false, false);
		};
	}

	private void CalculateTip(bool roundUp, bool roundDown)
	{
		if (Double.TryParse(BillInput.Text, out double netBill) && netBill > 0)
		{
			double percentage = Math.Round(TipPercentageSlider.Value);
			double tip = Math.Round(netBill * (percentage / 100.0), 2);

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

	private void OnNormalTip(object sender, EventArgs e) =>
		TipPercentageSlider.Value = 15;

	private void OnGenerousTip(object sender, EventArgs e) =>
		TipPercentageSlider.Value = 20;
}