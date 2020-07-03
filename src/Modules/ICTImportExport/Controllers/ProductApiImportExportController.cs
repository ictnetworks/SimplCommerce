using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using Microsoft.AspNetCore.Authorization;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Data;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace ICT.Module.ImportExport.Areas.Catalog
{
    [Area("Import / Export")]
    [Authorize(Roles = "admin")]
    [Route("api/importexport")]
    public class ProductApiImportExportController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMediaService _mediaService;
        private readonly IRepository<ProductAttributeValue> _productAttributeValue;
        private readonly IRepository<ProductLink> _productLink;
        private readonly IRepository<ProductOptionValue> _productOptionValueRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IProductService _productService;
        private readonly IRepository<ProductMedia> _productMediaRepository;
        private readonly IWorkContext _workContext;

        public ProductApiImportExportController(
            IRepository<Category> categoryRepository,
            IRepository<ProductCategory> productCategoryRepository,
            ICategoryService categoryService,
            IMediaService mediaService,
            IRepository<ProductAttribute> productAttributeValue,
            IRepository<ProductLink> productLink,
            IRepository<ProductOptionValue> productOptionValueRepository,
            IRepository<Product> productRepository,
            IProductService productService,
            IRepository<ProductMedia> productMediaRepository,
            IWorkContext workContext,
            IConfiguration config
            )
        {
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryService = categoryService;
            _mediaService = mediaService;
            //_productAttributeValue = productAttributeValue;
            _productLink = productLink;
            _productOptionValueRepository = productOptionValueRepository;
            _productRepository = productRepository;
            _productService = productService;
            _productMediaRepository = productMediaRepository;
            _workContext = workContext;

        }
        /**
        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
        var exportItems = await _productRepository
            .Query()
            .Select(x => new productRepository
            {
                Id = product.Id,

                Name = product.Name,

                Slug = product.Slug,

                MetaTitle = product.MetaTitle,

                MetaKeywords = product.MetaKeywords,

                MetaDescription = product.MetaDescription,

                Sku = product.Sku,

                Gtin = product.Gtin,

                ShortDescription = product.ShortDescription,

                Description = product.Description,

                Specification = product.Specification,

                OldPrice = product.OldPrice,

                Price = product.Price,

                SpecialPrice = product.SpecialPrice,

                SpecialPriceStart = product.SpecialPriceStart,

                SpecialPriceEnd = product.SpecialPriceEnd,

                IsFeatured = product.IsFeatured,

                IsPublished = product.IsPublished,

                IsCallForPricing = product.IsCallForPricing,

                IsAllowToOrder = product.IsAllowToOrder,

                CategoryIds = product.Categories.Select(x => x.CategoryId).ToList(),

                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage),

                BrandId = product.BrandId,

                TaxClassId = product.TaxClassId,

                StockTrackingIsEnabled = product.StockTrackingIsEnabled
            })
            .ToListAsync();

        var csvString = CsvConverter.ExportCsv(productsCSV);
        var csvBytes = Encoding.UTF8.GetBytes(csvString);
        var csvBytesWithUTF8BOM = Encoding.UTF8.GetPreamble().Concat(csvBytes).ToArray();
        return File(csvBytesWithUTF8BOM, "text/csv", "productCSV.csv");
        }


    **/

    }
}
