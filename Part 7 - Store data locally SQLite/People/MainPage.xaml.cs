namespace People;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnNewButtonClicked(object sender, EventArgs e)
	{
		StatusMessage.Text = "";
	}

	private void OnGetButtonClicked(object sender, EventArgs e)
	{
		StatusMessage.Text = "";
	}
}

