using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using ICT.Module.Moneris.Models;
using System.Net.Http;

namespace ICT.Module.Moneris.Controllers
{
    [Area("ICTMoneris")]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class ICTMonerisController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly ICurrencyService _currencyService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ICTMonerisController(
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository,
            ICurrencyService currencyService,
            IHttpClientFactory httpClientFactory)

        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _currencyService = currencyService;
            _httpClientFactory = httpClientFactory;

        }

        [HttpPost]
        public async Task<IActionResult> Charge()
        {
            var gatewayDomain = Request.Host.Value;
            //var accessToken = apiKEY;
            

            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if(cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(cart.Id, PaymentProviderHelper.ICTMonerisId, 0, OrderStatus.PendingPayment);
            if (!orderCreateResult.Success)
            {
                return BadRequest(orderCreateResult.Error);
            }

            var order = orderCreateResult.Value;
            var zeroDecimalOrderAmount = order.OrderTotal;
            if (!CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture))
            {
                zeroDecimalOrderAmount = zeroDecimalOrderAmount * 100;
            }

            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);
            var payment = new Payment()
            {
                OrderId = order.Id,
                Amount = order.OrderTotal,
                PaymentMethod = PaymentProviderHelper.ICTMonerisId,
                CreatedOn = DateTimeOffset.UtcNow
            };

            return View();
            //TODO: Need validation
            //foreach(var item in order.OrderItems)
            //{
            //    lineItemsRequest.Add(new TransactionLineItemRequest
            //    {
            //        Description = item.Product.Description.Substring(0, 255),
            //        Name = item.Product.Name,
            //        Quantity = item.Quantity,
            //        UnitAmount = item.ProductPrice,
            //        ProductCode = item.ProductId.ToString(),
            //        TotalAmount = item.ProductPrice * item.Quantity

            //    });
            //}


        }








    }
}
