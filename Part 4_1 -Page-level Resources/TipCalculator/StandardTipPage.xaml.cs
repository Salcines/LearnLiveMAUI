using System.Globalization;

namespace TipCalculator;

public partial class StandardTipPage : ContentPage
{
	private readonly Color _darkColor = Colors.Navy;
	private readonly Color _lightColor = Colors.Silver;

	public ColumnDefinitionCollection Columns { get; set; }

	public StandardTipPage()
	{
		InitializeComponent();
		
		if (CultureInfo.CurrentCulture.Name == "es-ES")
		{
			this.LayoutRoot.ColumnDefinitions[1].Width = new GridLength(2, GridUnitType.Star);
			this.LayoutRoot.WidthRequest += 1;
			this.LayoutRoot.WidthRequest -= 1;
		}

		BillInput.TextChanged += (s, e)
			=> CalculateTip();
	}

	private void CalculateTip()
	{
		if (Double.TryParse(BillInput.Text, out double netBill) && netBill > 0)
		{
			double tip = Math.Round(netBill * 0.15, 2);
			double totalBill = netBill + tip;

			TipOutput.Text = tip.ToString("C");
			TotalOutput.Text = totalBill.ToString("C");
		}
	}

	private void OnGotoCustom(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"{nameof(CustomTipPage)}");
	}

	private void OnLight(object sender, EventArgs e)
	{
		LayoutRoot.BackgroundColor = _lightColor;

		TipLabel.TextColor = _darkColor;
		BillLabel.TextColor = _darkColor;
		TotalLabel.TextColor = _darkColor;
		TipOutput.TextColor = _darkColor;
		TotalOutput.TextColor = _darkColor;
	}

	private void OnDark(object sender, EventArgs e)
	{
		LayoutRoot.BackgroundColor = _darkColor;

		TipLabel.TextColor = _lightColor;
		BillLabel.TextColor = _lightColor;
		TotalLabel.TextColor = _lightColor;
		TipOutput.TextColor = _lightColor;
		TotalOutput.TextColor = _lightColor;
	}
}