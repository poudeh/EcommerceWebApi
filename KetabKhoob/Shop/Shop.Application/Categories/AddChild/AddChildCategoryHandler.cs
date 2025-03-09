using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

public class AddChildCategoryHandler:IBaseCommandHandler<AddChildCategoryCommand , long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public AddChildCategoryHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.parendId);
        if (category == null)
            return OperationResult<long>.NotFound();
        category.AddChild(request.title, request.slug, request.seoData, _domainService);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);
    }
}