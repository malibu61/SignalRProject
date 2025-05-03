using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTableController : ControllerBase
    {
        private readonly IStoreTableService _storeTableService;

        public StoreTableController(IStoreTableService storeTableService)
        {
            _storeTableService = storeTableService;
        }

        [HttpGet("StoreTableList")]
        public IActionResult StoreTableList()
        {
            return Ok(_storeTableService.TGetListAll());
        }

        [HttpGet("OccupiedTableCount")]
        public IActionResult OccupiedTableCount()
        {
            return Ok(_storeTableService.TOccupiedTableCount());
        }


        [HttpGet("EmptyTableCount")]
        public IActionResult EmptyTableCount()
        {
            return Ok(_storeTableService.TEmptyTableCount());
        }
    }
}
