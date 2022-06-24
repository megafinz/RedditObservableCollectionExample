using ReactiveUI;

namespace RedditObservableCollectionExample.ViewModels;

public sealed class OrderItemViewModel : ViewModelBase
{
    private int _priceCents;

    public OrderItemViewModel(string title, int initialPriceCents)
    {
        Title = title;
        PriceCents = initialPriceCents;
    }
    
    public string Title { get; }

    public int PriceCents
    {
        get => _priceCents;
        set => this.RaiseAndSetIfChanged(ref _priceCents, value);
    }
}
