using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.DeleteInventory;

public class DeleteInventorySellerCommandHandler:IBaseCommandHandler<DeleteInventorySellerCommand>
{
    private readonly ISellerRepository _sellerRepository;

    public DeleteInventorySellerCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(DeleteInventorySellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.InventoryId);
        if (seller == null)
            return OperationResult.NotFound();
        seller.DeleteInventory(request.InventoryId);
        await _sellerRepository.Save();

        return OperationResult.Success();



    }
}