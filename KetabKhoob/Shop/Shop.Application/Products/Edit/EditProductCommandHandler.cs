﻿using AngleSharp.Io.Dom;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit;

public class EditProductCommandHandler:IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductDomainService _productDomainService;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService, IFileService fileService)
    {
        _productRepository = productRepository;
        _productDomainService = productDomainService;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {

        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();

        product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
            request.SecondarySubCategoryId, request.Slug, _productDomainService, request.SeoData);

        var oldImage = product.ImageName;
        if (request.ImageFile != null)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            product.SetProductImage(imageName);
        }
        var specifications = new List<ProductSpecification>();

        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });

        product.SetSpecification(specifications);
        await _productRepository.Save();
        RemoveOldImage(request.ImageFile, oldImage);
        return OperationResult.Success();





    }
    private void RemoveOldImage(IFormFile imageFile, string oldImageName)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.ProductImages, oldImageName);
        }
    }
}

