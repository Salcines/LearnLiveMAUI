using Translate = Phoneword.Resources.Languages.AppTranslation;
namespace Phoneword;

public partial class MainPage : ContentPage
{
	private string _translateNumber;

	public MainPage()
	{
		InitializeComponent();
    }

	private void OnTranslate(object sender, EventArgs e)
	{
		string inputNumber = PhoneNumberText.Text;

		_translateNumber = Core.PhonewordTranslator.ToNumber(inputNumber);

		if (!string.IsNullOrWhiteSpace(_translateNumber))
		{
			CallNumber.IsEnabled = true;
			CallNumber.Text      = $"{Translate.Button_Call} {_translateNumber}";
		}
		else
		{
			CallNumber.IsEnabled = false;
			CallNumber.Text      = Translate.Button_Call;
		}
	}

	private async void OnCall(object sender, EventArgs e)
	{
		if (await this.DisplayAlert(
				$"{Translate.Call_PopUp_Title}",
				$"{Translate.Call_PopUp_Title} {_translateNumber}",
				$"{Translate.Accept}",
				"NO"))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported)
				{
					PhoneDialer.Default.Open(_translateNumber);
				}
			}
			catch (ArgumentNullException)
			{
				await DisplayAlert($"{Translate.Error_PopUp_Title}", $"{Translate.ErrorNull_PopUp_Message}", "OK");
			}
			catch (Exception)
			{
				await DisplayAlert($"{Translate.Error_PopUp_Title}", $"{Translate.ErrorGen_PopUp_Message}", "OK");
			}
		}
	}
}

