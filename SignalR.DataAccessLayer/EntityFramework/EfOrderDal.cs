using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public decimal LastOrderPrice()
        {
            using (var context = new SignalRContext())
            {
                var valueLastId = context.Orders.OrderByDescending(x => x.OrderID).FirstOrDefault();
                var value = context.Orders.Where(x => x.OrderID == valueLastId.OrderID).Select(x => x.TotalPrice).FirstOrDefault();
                return value;
            }
        }

        public decimal TodayTotalOrderPrice()
        {
            using (var context = new SignalRContext())
            {
                //var value = context.Orders.Where(x => x.OrderDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Sum(x=>x.TotalPrice);
                //return value;

                var today = DateTime.Today;
                var value = context.Orders
                    .Where(x => x.OrderDate.Date == today)
                    .Sum(x => x.TotalPrice);
                return value;
            }
        }

        public int TotalActiveOrderCount()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Orders.Where(x => x.Description == "Ödenmedi").Count();
                return value;
            }
        }

        public int TotalOrderCount()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Orders.Count();
                return value;
            }
        }
    }
}
