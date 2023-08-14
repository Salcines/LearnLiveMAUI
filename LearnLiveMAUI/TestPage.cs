namespace Phoneword;

public class TestPage : ContentPage
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
            FontSize          = 18,
            FontAttributes    = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Add(descriptionLabel);

        counterLabel = new Label()
        {
            Text              = "Current count 0",
            FontSize          = 18,
            FontAttributes    = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Add(counterLabel);

        var myButton = new Button()
        {
            Text              = "Click me!",
            HorizontalOptions = LayoutOptions.Center
        };
        myStackLayout.Add(myButton);

        myButton.Clicked += MyButton_Clicked;
    }

    private void MyButton_Clicked(object sender, EventArgs e)
    {
        counter++;

        counterLabel.Text = $"Current count: {counter}";

        SemanticScreenReader.Announce(counterLabel.Text);
    }
}