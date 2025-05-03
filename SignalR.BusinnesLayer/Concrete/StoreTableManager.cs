using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.Concrete
{
    public class StoreTableManager : IStoreTableService
    {
        private readonly IStoreTableDal _storeTableDal;

        public StoreTableManager(IStoreTableDal storeTableDal)
        {
            _storeTableDal = storeTableDal;
        }

        public void TAdd(StoreTable entity)
        {
            _storeTableDal.Add(entity);
        }

        public void TDelete(StoreTable entity)
        {
            _storeTableDal.Delete(entity);
        }

        public int TEmptyTableCount()
        {
            return _storeTableDal.EmptyTableCount();
        }

        public StoreTable TGetById(int id)
        {
            return _storeTableDal.GetById(id);
        }

        public List<StoreTable> TGetListAll()
        {
            return _storeTableDal.GetListAll();
        }

        public int TOccupiedTableCount()
        {
            return _storeTableDal.OccupiedTableCount();
        }

        public void TUpdate(StoreTable entity)
        {
            _storeTableDal.Update(entity);
        }
    }
}
