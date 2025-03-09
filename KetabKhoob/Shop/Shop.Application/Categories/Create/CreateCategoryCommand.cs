using Common.Application;
using Common.Domain.ValueObject;

namespace Shop.Application.Categories.Create;

public record CreateCategoryCommand(string title ,string slug, SeoData seoData) : IBaseCommand<long>;