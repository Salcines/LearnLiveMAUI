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

		if (netBill == 0)
		{
			TipOutput.Text = "0";
			TotalOutput.Text = "0";
		}
	}

	private async void OnGotoCustom(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"{nameof(CustomTipPage)}");
	}

	private void OnLight(object sender, EventArgs e)
	{
		Resources["FgColor"] = _darkColor;
		Resources["BgColor"] = _lightColor;
	}

	private void OnDark(object sender, EventArgs e)
	{
		Resources["FgColor"] = _lightColor;
		Resources["BgColor"] = _darkColor;
	}
}