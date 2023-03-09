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
            new CardViewModel("Diamonds", "A") ,
            new CardViewModel("Spades", "J")   ,
            new CardViewModel("Clubs", "10")    ,
            new CardViewModel("Hearts", "Q")    ,
            new CardViewModel("Diamonds", "K") ,
        };

        // Asignamos la lista al ItemsSource del CollectionView
        cardListTestView.ItemsSource = cards;
    }
}