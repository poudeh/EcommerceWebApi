﻿using Common.Application;
using Common.Domain.ValueObject;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Create;

public class CreateProductCommand:IBaseCommand
{
    public string Title { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> Specifications { get; set; }

}