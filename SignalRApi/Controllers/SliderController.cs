using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _sliderService.TGetListAll();
            return Ok(_mapper.Map<List<Slider>>(values));
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {

            var values = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(values);
            return Ok("Slider Başarıyla Güncellendi");
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var values = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(values);
            return Ok("Slider Başarıyla Eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdSlider(int id)
        {
            var values = _sliderService.TGetById(id);
            return Ok(_mapper.Map<GetByIdSliderDto>(values));
        }
    }
}
