using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using MediatR;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.Models;


namespace ICT.Module.ImportExport.Areas.Catalog
{
    public class ProductImportExportController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly IProductPricingService _productPricingService;
        private readonly IContentLocalizationService _contentLocalizationService;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        
        


        public ProductImportExportController(
            IRepository<Product> productRepository,
            IMediaService mediaService,
            IMediator mediator,
            IProductPricingService productPricingService,
            IContentLocalizationService contentLocalizationService,
            IRepository<Category> categoryRepository,
            IRepository<Brand> brandRepository)

        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _mediator = mediator;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;

        }
    }
}
