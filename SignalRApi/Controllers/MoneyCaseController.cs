﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCaseController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            return Ok(value);
        }
    }
}
