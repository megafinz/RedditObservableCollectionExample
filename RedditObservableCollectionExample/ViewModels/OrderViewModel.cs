using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;

namespace RedditObservableCollectionExample.ViewModels;

public sealed class OrderViewModel : ViewModelBase
{
    public OrderViewModel(string title)
    {
        Title = title;
        Items.CollectionChanged += (_, _) => this.RaisePropertyChanged(nameof(TotalPrice));
    }
    
    public string Title { get; }
    
    public ObservableCollection<OrderItemViewModel> Items { get; } = new();

    public decimal TotalPrice => Items.Sum(x => x.Price);
}
