﻿using Microsoft.AspNetCore.Mvc;
using KVSolution.PIM.Application.Extentions;
using KVSolution.PIM.Infrastructure.Services.CryptoCurrency;
using Newtonsoft.Json;
using KVSolution.PIM.Application.Cryptocurrencies;

namespace KVSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrencyController : ControllerBase
    {
        public CryptocurrencyController()
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CommonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = CryptocurrencyService.Get(request.SearchText);

            var responseData = JsonConvert.DeserializeObject<CryptocurrencyModel>(data, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            return Ok(responseData);
        }

        [HttpGet("id")]
        public IActionResult GetByName([FromQuery]CommonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = CryptocurrencyService.GetById(request.SearchText);

            var responseData = JsonConvert.DeserializeObject<CryptocurrencyQuote>(data, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            return Ok(responseData);
        }
    }
}