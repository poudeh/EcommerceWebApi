﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.EF.CategoryAgg;
using Shop.Infrastructure.Persistent.EF.CommentAgg;
using Shop.Infrastructure.Persistent.EF.OrderAgg;
using Shop.Infrastructure.Persistent.EF.ProductAgg;
using Shop.Infrastructure.Persistent.EF.RoleAgg;
using Shop.Infrastructure.Persistent.EF.SellerAgg;
using Shop.Infrastructure.Persistent.EF.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.EF.UserAgg;

namespace Shop.Infrastructure.Persistent.EF;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

        services.AddTransient(_ => new DapperContext(connectionString));

        services.AddDbContext<ShopContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}
