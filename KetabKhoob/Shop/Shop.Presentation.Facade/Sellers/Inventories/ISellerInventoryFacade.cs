﻿using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Inventories.GetById;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);

    Task<InventoryDto?> GetById(long inventoryId);
    Task<List<InventoryDto>> GetList(long sellerId);
    Task<List<InventoryDto>> GetByProductId(long productId);
}

