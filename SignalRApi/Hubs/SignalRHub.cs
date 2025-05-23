﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IStoreTableService _storeTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(IProductService productService, ICategoryService categoryService, IOrderService orderService, IMoneyCaseService moneyCaseService, IStoreTableService storeTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _storeTableService = storeTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public static int clientCount { get; set; } = 0;

        SignalRContext context = new SignalRContext();
        public async Task SendStatistic()
        {
            var value1 = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value1);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("SendActiveCategoriesCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("SendPassiveCategoriesCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("SendHamburgerCount", value5);

            var value6 = _productService.TProductCountByCategoryNamePasta();
            await Clients.All.SendAsync("SendPastaCount", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("SendAvgPrice", value7);

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("SendMaxPriceProduct", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("SendMinPriceProduct", value9);

            var value10 = _productService.TProductPriceAvgForHamburger();
            await Clients.All.SendAsync("SendAvgPriceHamburger", value10);

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("SendSumOrderCount", value11);

            var value12 = _orderService.TTotalActiveOrderCount();
            await Clients.All.SendAsync("SendSumActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("SendLastOrder", value13);

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("SendSumMoneyCaseAmount", value14);

            var value15 = _orderService.TTodayTotalOrderPrice();
            await Clients.All.SendAsync("SendSumMoneyCaseAmountToday", value15);

            var value16 = _storeTableService.TOccupiedTableCount() + _storeTableService.TEmptyTableCount();
            await Clients.All.SendAsync("SendSumTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value1 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value1 + " ₺");//****

            var value2 = _orderService.TTotalActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", value2);//****

            var value3 = _storeTableService.TEmptyTableCount() + _storeTableService.TOccupiedTableCount();
            await Clients.All.SendAsync("ReceiveStoreTableCount", value3);//*****

            var value5 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5.ToString("0,00"));//****

            var value6 = _productService.TProductPriceAvgForHamburger();
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6);//****

            var value7 = _productService.TProductCountByCategoryNamePasta();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNamePasta", value7);//****

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveCountByHamurger", value9);

            var value10 = _storeTableService.TEmptyTableCount();
            await Clients.All.SendAsync("ReceiveEmptyTableCount", value10);

            var value11 = _storeTableService.TOccupiedTableCount();
            await Clients.All.SendAsync("ReceiveOccupiedTableCount", value11);

            int empty = _storeTableService.TEmptyTableCount();
            int occupied = _storeTableService.TOccupiedTableCount();

            int total = empty + occupied;
            double occupancyRate = total == 0 ? 0 : (double)occupied / total * 100;
            await Clients.All.SendAsync("ReceiveOccupancyRate", occupancyRate);
        }


        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", values);

            var values2 = _notificationService.TGelAllNotificationsByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", values2);
        }

        public async Task GetStoreTableStatus()
        {
            var values = _storeTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveStoreTableStatus", values);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
