using Common.Application;

namespace Shop.Application.Sellers.DeleteInventory;

public record DeleteInventorySellerCommand(long InventoryId):IBaseCommand;