namespace Phoneword;

public partial class TestPage : ContentPage
{
    private int counter = 0;

    private Label counterLabel;
    private Label descriptionLabel;
	public TestPage()
	{
		var myScrollView = new ScrollView();

        var myStackLayout = new VerticalStackLayout()
        {
            BackgroundColor = Colors.Black
        };

        myScrollView.Content = myStackLayout;

        descriptionLabel = new Label()
        {
            Text              = "Controls from C#",
            BackgroundColor   = Colors.White,
            FontSize          = 18,
            FontAttributes    = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Children.Add(descriptionLabel);

        counterLabel = new Label()
        {
            Padding           = 10,
            Text              = "Current count 0",
            BackgroundColor   = Colors.White,
            FontSize          = 18,
            FontAttributes    = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Children.Add(counterLabel);

        var myButton = new Button()
        {
            Margin            = 50,
            Text              = "Click me!",
            TextColor         = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor   = Colors.Aquamarine
        };
        myStackLayout.Children.Add(myButton);

        myButton.Clicked += MyButton_Clicked;

        this.Content = myScrollView;
    }

    private void MyButton_Clicked(object sender, EventArgs e)
    {
        counter++;

        counterLabel.Text = $"Current count: {counter}";

        SemanticScreenReader.Announce(counterLabel.Text);
    }
}