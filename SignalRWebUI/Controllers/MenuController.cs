﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDto;
using SignalRWebUI.Dtos.ProductDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz
                            // TempData["x"] = id; // Eğer bunu kullanıyorsanız

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Product/ProductWCategoryName");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }



        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int storeTableId)
        {
            if (storeTableId == 0)
            {
                return BadRequest("storeTableId = 0");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto
            {
                ProductID = id,
                StoreTableId = storeTableId
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7277/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            ////var jsonData2 = JsonConvert.SerializeObject(updateCategoryDto);
            ////StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client2.GetAsync("https://localhost:7277/api/StoreTable/ChangeStatusToTrue?id=" + storeTableId);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDto);

            //CreateBasketDto createBasketDto = new CreateBasketDto();
            //createBasketDto.ProductID=id;
            //var client=_httpClientFactory.  CreateClient();
            //var jsonData=JsonConvert.SerializeObject(createBasketDto);  
            //StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            //var responseMessage=await client.PostAsync("https://localhost:7277/api/Basket", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}

            //return Json(createBasketDto);
        }


    }
}
