using ReactiveUI;
using System;
using System.Reactive;

namespace RedditObservableCollectionExample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        AddNewOrderItemCommand = ReactiveCommand.Create(DoAddNewOrderItem);
    }

    public OrderViewModel Order { get; } = new("Greatest Order Of All Times");
        
    public ReactiveCommand<Unit, Unit> AddNewOrderItemCommand { get; }

    private void DoAddNewOrderItem()
    {
        var index = Order.Items.Count + 1;
        var priceCents = Random.Shared.Next(0, 100) * 100;
        Order.Items.Add(new OrderItemViewModel($"Item #{index}", priceCents));
    }
}
