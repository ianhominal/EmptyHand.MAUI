namespace EmptyHandv2;


public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnFlipClicked(object sender, EventArgs e)
    {
        cardView.Flip();
    }

    private void MainMenu_Loaded(object sender, EventArgs e)
    {
    }
}

