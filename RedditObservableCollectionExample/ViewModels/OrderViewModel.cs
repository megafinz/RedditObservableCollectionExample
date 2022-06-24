using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace RedditObservableCollectionExample.ViewModels;

public sealed class OrderViewModel : ViewModelBase
{
    public OrderViewModel(string title)
    {
        Title = title;
        Items.CollectionChanged += OnItemCollectionChanged;
    }

    public string Title { get; }
    
    public ObservableCollection<OrderItemViewModel> Items { get; } = new();

    public decimal TotalPrice => Items.Sum(x => (decimal) x.PriceCents) / 100m;
    
    // This is executed when a new item is added to or removed from the collection
    private void OnItemCollectionChanged(object? _, NotifyCollectionChangedEventArgs args)
    {
        switch (args.Action)
        {
            case NotifyCollectionChangedAction.Add:
            case NotifyCollectionChangedAction.Replace:
                if (args.NewItems is null) return;
            
                // Observe each new item for property changes.
                foreach (var newItem in args.NewItems.OfType<OrderItemViewModel>())
                {
                    newItem.PropertyChanged += OnItemPropertyChanged;
                }
                
                break;
        }
        
        this.RaisePropertyChanged(nameof(TotalPrice));
    }

    private void OnItemPropertyChanged(object? _, PropertyChangedEventArgs e)
    {
        // Update TotalPrice if item's PriceCents changed.
        if (e.PropertyName == nameof(OrderItemViewModel.PriceCents))
        {
            this.RaisePropertyChanged(nameof(TotalPrice));
        }
    }
}
