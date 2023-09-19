namespace People;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		// TODO: Initialize the repository property with the PersonRepository singleton object
	}
}
