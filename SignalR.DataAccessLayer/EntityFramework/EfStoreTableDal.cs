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
    public class EfStoreTableDal : GenericRepository<StoreTable>, IStoreTableDal
    {
        public EfStoreTableDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.StoreTables.Where(x => x.StoreTableID == id).FirstOrDefault();
                value.Status = false; 
                context.SaveChanges();
            }
        }

        public void ChangeStatusToTrue(int id)
        {
            using (var context = new SignalRContext())
            {
                var value = context.StoreTables.Where(x => x.StoreTableID == id).FirstOrDefault();
                value.Status = true;
                context.SaveChanges();
            }
        }

        public int EmptyTableCount()
        {
            using (var context = new SignalRContext())
            {
                var value = context.StoreTables.Where(x => x.Status == false).Count();
                return value;
            }
        }

        public int OccupiedTableCount()
        {
            using (var context = new SignalRContext())
            {
                var value = context.StoreTables.Where(x => x.Status == true).Count();
                return value;
            }
        }
    }
}
