﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObject;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg;

public class Category:AggregateRoot
{
    private Category()
    {
        Childs = new List<Category>();
    }
    public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
        Childs = new List<Category>();
    }

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Childs.Add(new Category(title, slug, seoData, service)
        {
            ParentId = Id
        });
    }

    public void Guard(string title, string slug, ICategoryDomainService service)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

        if (slug != Slug)
            if (service.IsSlugExist(slug))
                throw new SlugIsDuplicateException();
    }
}
