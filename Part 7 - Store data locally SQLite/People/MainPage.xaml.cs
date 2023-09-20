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

		App.PersonRepository.AddNewPerson(NewPerson.Text);
		StatusMessage.Text = App.PersonRepository.StatusMessage;
	}

	private void OnGetButtonClicked(object sender, EventArgs e)
	{
		StatusMessage.Text = "";

		var people = App.PersonRepository.GetAllPeople();

		PeopleList.ItemsSource = people;
	}
}

