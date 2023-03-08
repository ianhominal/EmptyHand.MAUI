namespace EmptyHandv2.Resources.Assets;
using Domain.ViewModels;

public partial class CardView : ContentView
{
    private CardViewModel viewModel;

    public CardView()
    {
        InitializeComponent();
        BindingContext = viewModel = new CardViewModel("Diamonds", "A");
    }

    public CardView(CardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewModel;
    }

    public void Flip()
    {
        viewModel.Flip();
    }
}