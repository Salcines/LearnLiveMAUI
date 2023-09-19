using PartsClient.Views;

namespace PartsClient;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddPartView), typeof(AddPartView));
	}
}
