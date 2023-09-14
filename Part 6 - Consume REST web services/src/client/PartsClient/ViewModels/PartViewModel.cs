using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PartsClient.Models;
using PartsClient.Views;

namespace PartsClient.ViewModels;
public class PartsViewModel : INotifyPropertyChanged
{
	public Command LoadDataCommand { get; private set; }
	public Command PartSelectedCommand { get; private set; }
	public Command AddNewPartCommand { get; private set; }

	public PartsViewModel()
	{
		Parts = new ObservableCollection<Part>();
		LoadDataCommand = new Command(async () =>
			await LoadData());
		PartSelectedCommand = new Command(async () =>
			await PartSelected());
		AddNewPartCommand = new Command(async () =>
			await Shell.Current.GoToAsync(nameof(AddPartView)));

		MessagingCenter.Subscribe<AddPartViewModel>(this, "refresh", async (sender) => await LoadData());

		Task.Run(LoadData);
	}


	private bool _isRefreshing;

	public bool IsRefreshing
	{
		get => _isRefreshing;
		set
		{
			if (_isRefreshing == value)
			{
				return;
			}

			_isRefreshing = value;
			OnPropertyChanged(nameof(IsRefreshing));
		}
	}


	private bool _isBusy;

	public bool IsBusy
	{
		get => _isBusy;
		set
		{
			if (_isBusy == value)
			{
				return;
			}

			_isBusy = value;
			OnPropertyChanged(nameof(IsBusy));
		}
	}


	private Part _selectedPart;

	public Part SelectedPart
	{
		get => _selectedPart;
		set
		{
			if (_selectedPart == value)
			{
				return;
			}

			_selectedPart = value;
			OnPropertyChanged(nameof(SelectedPart));
		}
	}

	public ObservableCollection<Part> Parts { get; set; }


	private async Task PartSelected()
	{
		if (SelectedPart == null)
		{
			return;
		}

		var navigationParameter = new Dictionary<string, object>()
		{
			{ "part", SelectedPart }
		};

		await Shell.Current.GoToAsync(nameof(AddPartView), navigationParameter);

		MainThread.BeginInvokeOnMainThread((() => SelectedPart =null));
	}

	private async Task LoadData()
	{
		if (IsBusy)
		{
			return;
		}

		try
		{
			IsRefreshing = true;
			IsBusy = true;

			var partCollection = await PartsManager.GetAll();

			MainThread.BeginInvokeOnMainThread((() =>
			{
				Parts.Clear();

				foreach (Part part in partCollection)
				{
					Parts.Add(part);
				}
			}));
		}
		finally
		{
			IsRefreshing = false;
			IsBusy = false;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
