using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories.AddChild;
using Shop.Application.Comments.ChangeStatus;
using Shop.Infrastructure.Persistent.EF;
using Shop.Query.Categories.GetById;
using MediatR;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Application.Roles.Create;
using Shop.Presentation.Facade;


namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            // Register MediatR for specific handlers
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<Directories>();
                config.RegisterServicesFromAssemblyContaining<GetCategoryByIdQuery>();

            });

            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IDomainUserService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();

            services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);
            services.InitFacadeDependency();
        }
    }
}
