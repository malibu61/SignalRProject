﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.Abstract
{
    public interface IStoreTableService : IGenericService<StoreTable>
    {
        int TOccupiedTableCount();
        int TEmptyTableCount();
        void TChangeStatusToTrue(int id);
        void TChangeStatusToFalse(int id);
    }
}
