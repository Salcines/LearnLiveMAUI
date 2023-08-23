namespace Aligment;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnHorizontalStartClicked(object sender, EventArgs e)
		=> Target.HorizontalOptions = LayoutOptions.Start;

	private void OnHorizontalCenterClicked(object sender, EventArgs e)
	=> Target.HorizontalOptions = LayoutOptions.Center;

	private void OnHorizontalEndClicked(object sender, EventArgs e)
	=> Target.HorizontalOptions = LayoutOptions.End;

	private void OnHorizontalFillClicked(object sender, EventArgs e)
	=> Target.HorizontalOptions = LayoutOptions.Fill;

	private void OnVerticalStartClicked(object sender, EventArgs e)
	=> Target.VerticalOptions = LayoutOptions.Start;

	private void OnVerticalCenterClicked(object sender, EventArgs e)
		=> Target.VerticalOptions = LayoutOptions.Center;

	private void OnVerticalEndClicked(object sender, EventArgs e)
	=> Target.VerticalOptions = LayoutOptions.End;

	private void OnVerticalFillClicked(object sender, EventArgs e)
		=> Target.VerticalOptions = LayoutOptions.Fill;


}

