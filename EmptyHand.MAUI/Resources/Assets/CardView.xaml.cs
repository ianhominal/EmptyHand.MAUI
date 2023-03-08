using Domain.ViewModels;

namespace EmptyHandv2.Resources.Assets;
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

    public string Rank
    {
        get { return viewModel.Rank; }
        set { viewModel.Rank = value; }
    }

    public static readonly BindableProperty ShadowVisibleProperty =
           BindableProperty.Create(nameof(ShadowVisible), typeof(bool?), typeof(CardView), default(bool?), propertyChanged: OnShadowVisiblePropertyChanged);

    private static void OnShadowVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue != null)
        {
            ((CardView)bindable).InvalidateMeasure();
        }
    }

    public bool? ShadowVisible
    {
        get { return (bool?)GetValue(ShadowVisibleProperty); }
        set { SetValue(ShadowVisibleProperty, value); }
    }

    public void Flip()
    {
        viewModel.Flip();
    }
}