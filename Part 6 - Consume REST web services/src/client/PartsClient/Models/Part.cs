using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartsClient.Models;

[Serializable]
public class Part : INotifyPropertyChanged
{
	private string _partId;

	public string PartId
	{
		get => _partId;
		set
		{
			if (_partId == value)
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

	private string _supplier;

	public string Supplier
	{
		get => _supplier;
		set
		{
			if (_supplier == value)
			{
				return;
			}
			_supplier = value;
			OnPropertyChanged(nameof(Supplier));
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

	public List<string> Suppliers { get; set; }
	public DateTime PartAvailableData { get; set; }

	public string SuppliersString
	{
		get
		{
			string result = string.Empty;

			foreach (var supplier in Suppliers)
			{
				result = $"{supplier}, ";
			}

			result = result.Trim(',', ' ');

			return result;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}