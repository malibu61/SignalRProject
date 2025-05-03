using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using System.Runtime.CompilerServices;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("TotalActiveOrderCount")]
        public IActionResult TotalActiveOrderCount()
        {
            return Ok(_orderService.TTotalActiveOrderCount());
        }


        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayTotalOrderPrice")]
        public IActionResult TodayTotalOrderPrice()
        {
            return Ok(_orderService.TTodayTotalOrderPrice());
        }
    }
}
