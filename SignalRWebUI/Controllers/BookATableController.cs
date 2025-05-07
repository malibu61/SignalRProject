using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using SignalRWebUI.Dtos.BookingDto;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("https://localhost:7277/api/Contact");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //JArray item = JArray.Parse(responseBody);
            //string value = item[0]["location"].ToString();
            //ViewBag.location = value;
            //ViewBag.location = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d61496.02206159275!2d34.81038937033628!3d38.64097342190762!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x152aa3539db8f0a3%3A0x7cba0b0a99d0e80!2zS2FwYWRva3lhLCBOZXZxZWhpci_EsHN0YW4!5e0!3m2!1str!2str!4v1714991862597!5m2!1str!2str";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {

            HttpClient client2 = new HttpClient();
            HttpResponseMessage response = await client2.GetAsync("https://localhost:7277/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //JArray item = JArray.Parse(responseBody);
            //string value = item[0]["location"].ToString();
            //ViewBag.location = value;

            createBookingDto.Description = "b";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Booking", stringContent);



            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }

        }
    }
}
