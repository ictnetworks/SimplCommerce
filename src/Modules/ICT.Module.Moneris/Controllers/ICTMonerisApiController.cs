using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using ICT.Module.Moneris.Models;
using System.Threading.Tasks;


namespace ICT.Module.Moneris.Controllers
{
    [Area("PaymentICTMoneris")]
    [Authorize(Roles = "admin")]
    [Route("api/ictMoneris")]
    public class ICTMonerisApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public ICTMonerisApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }
        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var ICTMonerisProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.ICTMonerisId);
            var model = JsonConvert.DeserializeObject<ICTMonerisConfigForm>(ICTMonerisProvider.AdditionalSettings);
            return Ok(model);
        }
        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] ICTMonerisConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var ICTMonerisProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.ICTMonerisId);
                ICTMonerisProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
