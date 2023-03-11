using Domain.Models;
using Domain.ViewModels;
namespace EmptyHandv2.Resources.Assets;
public partial class CardView : ContentView
{
    public CardViewModel viewModel { get; set; }

    public CardView()
    {
        InitializeComponent();
        BindingContext = viewModel = new CardModel("Diamonds", "A").ToCardViewModel();
    }

    public CardView(CardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewModel;
    }


    public bool ShadowVisible
    {
        get { return viewModel.ShadowVisible; }
        set { viewModel.ShadowVisible = value; }
    }

    public Thickness ShadowMargin
    {
        get { return viewModel.ShadowMargin; }
        set { viewModel.ShadowMargin = value; }
    }


    public void Flip()
    {
        viewModel.Flip();
    }
}