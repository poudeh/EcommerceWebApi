using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount;

public record DecreaseOrderItemCountCommand(long userId , long ItemId , int count):IBaseCommand;
