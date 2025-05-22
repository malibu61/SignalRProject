﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.StoreTableDto;

namespace SignalRWebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CustomerTableList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/StoreTable");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStoreTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
