﻿using System;
using System.Collections.Generic;
using WarehouseWithEntityFramework.Entities;

namespace WarehouseWithEntityFramework.Repositories
{
    public interface IGoodsRepository:IRepository<Good>, IDisposable
    {
        public Good GetMaxQuantityGood();
        public Good GetMinQuantityGood();

        public Good GetMaxCostGood();
        public Good GetMinCostGood();

        public IEnumerable<Good> GetGoodsByType(int typeId);
        public IEnumerable<Good> GetGoodsBySupplier(int supplierId);
        public IEnumerable<Good> GetGoodsByPassedDays(int passedDays);

        public Good GetTheOldestGood();

        public void GetAvgGoodsQuantityByType();
    }
}
