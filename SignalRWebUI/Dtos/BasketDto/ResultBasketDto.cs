﻿using SignalR.EntityLayer.Entities;

namespace SignalRWebUI.Dtos.BasketDto
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int StoreTableID { get; set; }
    }
}
