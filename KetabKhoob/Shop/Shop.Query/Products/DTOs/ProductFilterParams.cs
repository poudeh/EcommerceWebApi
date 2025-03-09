using Common.Query.Filter;

namespace Shop.Query.Products.DTOs;

public class ProductFilterParams:BaseFilterParam //The elements That we wanna search,
{
    public string Title { get; set; }
    public long Id { get; set; }
    public string Slug { get; set; }
}