using Domain.ViewModels;
using EmptyHandv2.Resources.Assets;
using System.Collections.ObjectModel;

namespace EmptyHandv2;



public partial class MainMenu : ContentPage
{


    public MainMenu()
	{
		InitializeComponent();


    }

	private void DrawTitle()
	{
        // Crear el label
        Label emptyHandLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
            Text = "Empty Hand",
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.Black
        };

        // Añadir el label al grid principal
        grdTitle.Children.Add(emptyHandLabel);

        // Crear el grid de las cartas
        Grid cardsGrid = new Grid()
        {
            Margin = new Thickness(0, 30, 0, 0)
        };

        // Crear las cartas
        CardView card1 = new CardView(new CardModel().ToModel()("Clubs", "10"))
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(-4, 4, 0, 0),
            Margin = new Thickness(-200, 5, 0, 0),
            Rotation = -10,
            RotationX = 50
        };

        CardView card2 = new CardView(new CardViewModel("Diamonds", "J"))
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(-4, 4, 0, 0),
            Margin = new Thickness(-100, 0, 0, 0),
            Rotation = -20,
            RotationX = 50
        };

        CardView card3 = new CardView(new CardViewModel("Clubs", "A"))
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(4, 4, 0, 0),
            Margin = new Thickness(200, 5, 0, 0),
            Rotation = 10,
            RotationX = 50
        };

        CardView card4 = new CardView(new CardViewModel("Hearts", "K"))
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(4, 4, 0, 0),
            Margin = new Thickness(100, 0, 0, 0),
            Rotation = 20,
            RotationX = 50
        };

        CardView card5 = new CardView(new CardViewModel("Spades", "Q"))
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(0, 5, 0, 0),
            RotationX = 50
        };

        // Añadir las cartas al grid de las cartas
        cardsGrid.Children.Add(card1);
        cardsGrid.Children.Add(card2);
        cardsGrid.Children.Add(card3);
        cardsGrid.Children.Add(card4);
        cardsGrid.Children.Add(card5);

        // Añadir el grid de las cartas al grid principal
        grdTitle.Children.Add(cardsGrid);

    }



    private void MainMenu_Loaded(object sender, EventArgs e)
    {
        DrawTitle();
    }

    private async void NewGame_Clicked(object sender, EventArgs e)
    {
        await this.Navigation.PushAsync(new GamePage());
    }

    private void OnGameTapped(object sender, EventArgs e)
    {
        // Aquí puedes agregar el código que deseas ejecutar cuando se hace clic en un elemento del CollectionView
        var selectedGame = (sender as Image)?.BindingContext;


    }
}

