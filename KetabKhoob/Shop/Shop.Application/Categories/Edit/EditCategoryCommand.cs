using Common.Application;
using Common.Domain.ValueObject;

namespace Shop.Application.Categories.Edit;

public record EditCategoryCommand(long Id , string Title , string Slug , SeoData SeoData):IBaseCommand;