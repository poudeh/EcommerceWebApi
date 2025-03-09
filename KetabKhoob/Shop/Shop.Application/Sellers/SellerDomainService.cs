
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService:ISellerDomainService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerDomainService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public bool IsValidSellerInformation(Seller seller)
        {
            var sellerResult = _sellerRepository
                .Exists(r => r.NationalCode == seller.NationalCode || r.UserId == seller.UserId);
            return !sellerResult;
        }

        public bool NationalCodeExistInDataBase(string nationalCode)
        {
            return _sellerRepository.Exists(r => r.NationalCode == nationalCode);
            
        }
    }
}
