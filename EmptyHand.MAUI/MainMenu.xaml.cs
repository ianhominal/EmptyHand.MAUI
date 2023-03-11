using Domain.Interfaces;
using Domain.Models;
using EmptyHandv2.Resources.Assets;
using Services;

namespace EmptyHandv2;



public partial class MainMenu : ContentPage, IMainMenu
{
    GoogleService googleService;


    public MainMenu()
    {
        InitializeComponent();
        googleService = new GoogleService();


    }
    private void MainMenu_Loaded(object sender, EventArgs e)
    {
        DrawTitle();
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
        CardView card1 = new CardView(new CardModel("Ckubs", "10").ToCardViewModel())
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(-4, 4, 0, 0),
            Margin = new Thickness(-200, 5, 0, 0),
            Rotation = -10,
            RotationX = 50
        };

        CardView card2 = new CardView(new CardModel("Diamonds", "J").ToCardViewModel())
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(-4, 4, 0, 0),
            Margin = new Thickness(-100, 0, 0, 0),
            Rotation = -20,
            RotationX = 50
        };

        CardView card3 = new CardView(new CardModel("Clubs", "A").ToCardViewModel())
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(4, 4, 0, 0),
            Margin = new Thickness(200, 5, 0, 0),
            Rotation = 10,
            RotationX = 50
        };

        CardView card4 = new CardView(new CardModel("Hearts", "K").ToCardViewModel())
        {
            HorizontalOptions = LayoutOptions.Center,
            ShadowMargin = new Thickness(4, 4, 0, 0),
            Margin = new Thickness(100, 0, 0, 0),
            Rotation = 20,
            RotationX = 50
        };

        CardView card5 = new CardView(new CardModel("Spades", "Q").ToCardViewModel())
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


    private async void NewGame_Clicked(object sender, EventArgs e)
    {
        await this.Navigation.PushAsync(new GamePage());
    }

    private void OnGameTapped(object sender, EventArgs e)
    {
        // Aquí puedes agregar el código que deseas ejecutar cuando se hace clic en un elemento del CollectionView
        var selectedGame = (sender as Image)?.BindingContext;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await googleService.GoogleLogin();
    }
    

    public void RefreshGameList(List<GameModel> games)
    {
        CVOnlineGames.Dispatcher.Dispatch(() =>
        {
            CVOnlineGames.ItemsSource = games;
        });
    }

    public void CreateNewGame(GameModel game)
    {
        throw new NotImplementedException();
    }

    public void StartNewGame(GameModel game)
    {
        throw new NotImplementedException();
    }

    public void GameClosed(string enemyPlayer)
    {
        throw new NotImplementedException();
    }
}

