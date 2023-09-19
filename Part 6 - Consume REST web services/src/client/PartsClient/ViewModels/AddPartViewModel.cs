using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PartsClient.Models;

namespace PartsClient.ViewModels;

public class AddPartViewModel : INotifyPropertyChanged
{
	public ICommand DoneEditingCommand { get; private set; }
	public ICommand SaveCommand { get; private set; }
	public ICommand DeleteCommand { get; private set; }

	public AddPartViewModel()
	{
		DoneEditingCommand = new Command(async () =>
			await DoneEditing());
		SaveCommand = new Command(async () =>
			await SaveData());
		DeleteCommand = new Command(async () =>
			await DeletePart());
	}

	private string _partId;

	public string PartId
	{
		get => _partId;
		set
		{
			if(_partId == value)
			{
				return;
			}

			_partId = value;
			OnPropertyChanged(nameof(PartId));
		}
	}

	private string _partName;

	public string PartName
	{
		get => _partName;
		set
		{
			if (_partName == value)
			{
				return;
			}

			_partName = value;
			OnPropertyChanged(nameof(PartName));
		}
	}

	private string _suppliers;

	public string Suppliers
	{
		get => _suppliers;
		set
		{
			if (_suppliers == value)
			{
				return;
			}

			_suppliers = value;
			OnPropertyChanged(nameof(Suppliers));
		}
	}

	private string _partType;

	public string PartType
	{
		get => _partType;
		set
		{
			if (_partType == value)
			{
				return;
			}

			_partType = value;
			OnPropertyChanged(nameof(PartType));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private async Task SaveData()
	{
		if (string.IsNullOrWhiteSpace(PartId))
		{
			await InsertPart();
		}
		else
		{
			await UpdatePart();
		}
	}

	private async Task InsertPart()
	{
		await PartsManager.Add(PartName, Suppliers, PartType);

		MessagingCenter.Send(this, "refresh");

		await Shell.Current.GoToAsync("..");
	}

	private async Task UpdatePart()
	{
		Part partToSave = new()
		{
			PartId = PartId,
			PartName = PartName,
			PartType = PartType,
			Suppliers = Suppliers.Split(",").ToList()
		};

		await PartsManager.Update(partToSave);

		MessagingCenter.Send(this, "refresh");

		await Shell.Current.GoToAsync("..");
	}

	private async Task DeletePart()
	{
		if (string.IsNullOrWhiteSpace(PartId))
		{
			return;
		}

		bool action = await Shell.Current.DisplayAlert("Delete item", "Do you want delete the item?", "Yes", "No");

		if (action)
		{
			await PartsManager.Delete(PartId);

			MessagingCenter.Send(this, "refresh");

			await Shell.Current.DisplayAlert("Delete item", "The Item has benn deleted", "Ok");
		}

		await Shell.Current.GoToAsync("..");
	}

	private async Task DoneEditing()
	{
		await Shell.Current.GoToAsync("..");
	}
}
