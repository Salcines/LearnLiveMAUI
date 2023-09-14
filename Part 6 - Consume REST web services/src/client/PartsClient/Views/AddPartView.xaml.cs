using PartsClient.Models;
using PartsClient.ViewModels;

namespace PartsClient.Views;

[QueryProperty("PartToDisplay", "part")]
public partial class AddPartView : ContentPage
{
	AddPartViewModel viewModel;
	public AddPartView()
	{
		InitializeComponent();

		viewModel = new AddPartViewModel();
		BindingContext = viewModel;
	}

	private Part _partToDisplay;

	public Part PartToDisplay
	{
		get => _partToDisplay;
		set
		{
			if (_partToDisplay == value)
			{
				return;
			}

			_partToDisplay = value;

				viewModel.PartId = _partToDisplay.PartId;
				viewModel.PartName = _partToDisplay.PartName;
				viewModel.PartType = _partToDisplay.PartType;
				viewModel.Suppliers = _partToDisplay.SuppliersString;
		}
	}
}