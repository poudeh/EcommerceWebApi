using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderDiscount:BaseValueObject
{
    public OrderDiscount(string discountTitle, int discountAmount)
    {
        DiscountTitle = discountTitle;
        DiscountAmount = discountAmount;
    }
    public string DiscountTitle { get; private set; }
    public int DiscountAmount { get;private set; }
    
}