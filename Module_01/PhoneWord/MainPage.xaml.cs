namespace Phoneword;

public partial class MainPage : ContentPage
{
	private string translateNumber;

	public MainPage()
	{
		InitializeComponent();
    }

	private void OnTranslate(object sender, EventArgs e)
	{
		string inputNumber = PhoneNumberText.Text;

		translateNumber = Core.PhonewordTranslator.ToNumber(inputNumber);

		if (!string.IsNullOrWhiteSpace(translateNumber))
		{
			CallNumber.IsEnabled = true;
			CallNumber.Text      = $"Llamar al {translateNumber}";
		}
		else
		{
			CallNumber.IsEnabled = false;
			CallNumber.Text      = "Llamar";
		}
	}

	private async void OnCall(object sender, EventArgs e)
	{
		if (await this.DisplayAlert(
				"Marcar el número",
				$"Desea llamar al {translateNumber}",
				"YES",
				"NO"))
		{
			// TODO: Call number
		}
	}
}

