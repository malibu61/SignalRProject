using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using SignalR.DtoLayer.BookingDto;
using FluentValidation;
using FluentValidation.Results;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookATableController(IHttpClientFactory httpClientFactory, IValidator<CreateBookingDto> validator)
        {
            _httpClientFactory = httpClientFactory;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7277/api/Contact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var contactArray = JArray.Parse(responseBody);
            var location = contactArray[0]["location"]?.ToString();

            ViewBag.location = location;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var validationResult = await _validator.ValidateAsync(createBookingDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                using var clientMap = _httpClientFactory.CreateClient();
                var response = await clientMap.GetAsync("https://localhost:7277/api/Contact");
                var responseBody = await response.Content.ReadAsStringAsync();
                var contactArray = JArray.Parse(responseBody);
                var location = contactArray[0]["location"]?.ToString();
                ViewBag.location = location;

                return View(createBookingDto);
            }

            createBookingDto.Description = "b";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError(string.Empty, "Rezervasyon sırasında bir hata oluştu.");
            return View(createBookingDto);
        }
    }
}
