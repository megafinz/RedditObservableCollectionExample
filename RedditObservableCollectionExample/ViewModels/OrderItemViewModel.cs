namespace RedditObservableCollectionExample.ViewModels;

public sealed class OrderItemViewModel : ViewModelBase
{
    public OrderItemViewModel(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
    
    public string Title { get; }
    
    public decimal Price { get; }
}
