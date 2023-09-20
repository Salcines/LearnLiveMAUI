using People.Models;

namespace People;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnNewButtonClicked(object sender, EventArgs e)
	{
		StatusMessage.Text = "";

		await App.PersonRepository.AddNewPersonAsync(NewPerson.Text);
		StatusMessage.Text = App.PersonRepository.StatusMessage;

		NewPerson.Text = string.Empty;
	}

	private async void OnGetButtonClicked(object sender, EventArgs e)
	{
		StatusMessage.Text = "";

		var people = await App.PersonRepository.GetAllPeopleAsync();

		PeopleList.ItemsSource = people;
	}

	private void NewPersonTextChanged(object sender, TextChangedEventArgs e)
	{
		if (NewPerson.Text != string.Empty)
		{
			PeopleList.ItemsSource = new List<Person>();
		}
	}
}

