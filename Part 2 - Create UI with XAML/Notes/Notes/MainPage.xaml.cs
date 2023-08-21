using System.Globalization;
using Notes.Resources.Culture;

namespace Notes;

public partial class MainPage : ContentPage
{
	private string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	private Editor _editor;
	public MainPage()
	{
		CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

		var notesHeading = new Label()
			{ Text = Main.Heading_Title, HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };

		_editor = new Editor() { Placeholder = Main.Editor_Placeholder, HeightRequest = 100 };
		_editor.Text = File.Exists(_fileName) ? File.ReadAllText(_fileName) : string.Empty;

		var buttonGrid = new Grid() { HeightRequest = 40.0 };
		buttonGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
		buttonGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30.0, GridUnitType.Absolute) });
		buttonGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });

		var saveButton = new Button() { WidthRequest = 100, Text = Main.Save_Button };
		saveButton.Clicked += OnSaveButtonClicked;
		Grid.SetColumn(saveButton, 0);
		buttonGrid.Children.Add(saveButton);

		var deleteButton = new Button() { WidthRequest = 100, Text = Main.Delete_Button };
		deleteButton.Clicked += OnDeleteButtonClicked;
		Grid.SetColumn(deleteButton, 2);
		buttonGrid.Children.Add(deleteButton);

		var stackLayout = new VerticalStackLayout()
		{
			Padding = new Thickness(30, 60, 30, 30),
			Children = { notesHeading, _editor, buttonGrid }
		};

		this.Content = stackLayout;

	}

	private void OnSaveButtonClicked(object sender, EventArgs e)
	{
		File.WriteAllText(_fileName, _editor.Text);
	}

	private void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		if (File.Exists(_fileName))
		{
			File.Delete(_fileName);
		}

		_editor.Text = string.Empty;
	}
}

