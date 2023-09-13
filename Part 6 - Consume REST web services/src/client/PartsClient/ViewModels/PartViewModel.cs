using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartsClient.ViewModels;
public class PartsViewModel : INotifyPropertyChanged
{

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
