using System.Globalization;
using Notes.Resources.Culture;

namespace Notes;

public partial class MainPage : ContentPage
{
	private readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	
	public MainPage()
	{
		InitializeComponent();

		Editor.Text = (File.Exists(_fileName)) ? File.ReadAllText(_fileName) : string.Empty;
	}

	private void OnSaveButtonClicked(object sender, EventArgs e)
	{
		File.WriteAllText(_fileName, Editor.Text);
	}

	private void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		if (File.Exists(_fileName))
		{
			File.Delete(_fileName);
		}

		Editor.Text = string.Empty;
	}
}

