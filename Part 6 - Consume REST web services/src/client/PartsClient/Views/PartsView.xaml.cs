using PartsClient.ViewModels;

namespace PartsClient.Views;

public partial class PartsView : ContentPage
{
	public PartsView()
	{
		InitializeComponent();

		BindingContext = new PartsViewModel();
	}
}