﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IStoreTableDal : IGenericDal<StoreTable>
    {
        int OccupiedTableCount();
        int EmptyTableCount();
        void ChangeStatusToFalse(int id);
        void ChangeStatusToTrue(int id);
    }
}
