using Domain.Models;
using Domain.ViewModels;
using System.Collections.ObjectModel;

namespace EmptyHandv2;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();

        var cards = new ObservableCollection<CardViewModel>
        {
            new CardModel("Diamonds", "A").ToCardViewModel() ,
            new CardModel("Spades", "J").ToCardViewModel() ,
            new CardModel("Clubs", "10").ToCardViewModel()  ,
            new CardModel("Hearts", "Q").ToCardViewModel()  ,
            new CardModel("Diamonds", "K").ToCardViewModel() ,
        };

        // Asignamos la lista al ItemsSource del CollectionView
        cardListTestView.ItemsSource = cards;
    }
}