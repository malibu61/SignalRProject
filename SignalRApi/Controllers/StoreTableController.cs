using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.StoreTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StoreTableController : ControllerBase
	{
		private readonly IStoreTableService _storeTableService;
		private readonly IMapper _mapper;


		public StoreTableController(IStoreTableService storeTableService)
		{
			_storeTableService = storeTableService;
		}

		[HttpGet]
		public IActionResult StoreTableList()
		{
			var values = _storeTableService.TGetListAll();
			return Ok(/*_mapper.Map<List<ResultStoreTableDto>>(values)*/values);
		}
		[HttpPost]
		public IActionResult CreateStoreTable(CreateStoreTableDto createStoreTableDto)
		{
			createStoreTableDto.Status = false;

			//var values = /*_mapper.Map<StoreTable>(createStoreTableDto);*/

			var values = new StoreTable()
			{
				Name = createStoreTableDto.Name,
				Status = false
			};

			_storeTableService.TAdd(values);
			return Ok("Masa Başarılı Bir Şekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStoreTable(int id)
		{
			var value = _storeTableService.TGetById(id);
			_storeTableService.TDelete(value);
			return Ok("Masa Silindi");
		}
		[HttpPut]
		public IActionResult UpdateStoreTable(UpdateStoreTableDto updateStoreTableDto)
		{
			//var value = _mapper.Map<StoreTable>(updateStoreTableDto);

			var value = new StoreTable()
			{
				StoreTableID = updateStoreTableDto.StoreTableID,
				Name = updateStoreTableDto.Name,
				Status = updateStoreTableDto.Status
			};

			_storeTableService.TUpdate(value);
			return Ok("Masa Bilgisi Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetStoreTable(int id)
		{
			var value = _storeTableService.TGetById(id);
			return Ok(/*_mapper.Map<GetByIdStoreTableDto>*/(value));
		}

		//	  [HttpGet("StoreTableList")]
		//      public IActionResult StoreTableList()
		//      {
		//          return Ok(_storeTableService.TGetListAll());
		//      }

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

		[HttpGet("ChangeStatusToFalse")]
		public IActionResult ChangeStatusToFalse(int id)
		{ 
			_storeTableService.TChangeStatusToFalse(id);
            return Ok("False'a çevirme işlemi başarılı");
        }

        [HttpGet("ChangeStatusToTrue")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _storeTableService.TChangeStatusToTrue(id);
            return Ok("True'a çevirme işlemi başarılı");
        }
    }
}
