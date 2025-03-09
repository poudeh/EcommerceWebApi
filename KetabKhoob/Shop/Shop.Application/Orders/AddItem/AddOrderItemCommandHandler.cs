using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler:IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();
        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        var Order = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (Order == null)
        {
            Order = new Order(request.UserId);
            Order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
            _orderRepository.Add(Order);
        }
        else
        {
            Order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
        }


        if (ItemCountBiggerThanInventoryCount(inventory, Order))
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        await _orderRepository.Save();
        return OperationResult.Success();


    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}