using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount;

public record IncreaseOrderItemCountCommand(long userId, long ItemId, int count) :IBaseCommand;