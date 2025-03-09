using Common.Application;
using Common.Domain.ValueObject;

namespace Shop.Application.Categories.AddChild;

public record AddChildCategoryCommand(long parendId , string title, string slug, SeoData seoData) :IBaseCommand<long>;