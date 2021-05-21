using System.Collections.Generic;
using WarehouseWithEntityFramework.Entities;
using System.Linq;
using MoreLinq;
using System;

namespace WarehouseWithEntityFramework.Repositories
{
    public class GoodsRepository: Repository<Good>, IGoodsRepository
    {
        public GoodsRepository():base()
        {

        }
        public void GetAvgGoodsQuantityByType()
        {
            var avgGoodsQuantityByType = warehouseContext.Goods.GroupBy(g => g.Type.Type)
                                        .Select(g => new { type = g.Key, avgQuantity = g.Average(g => g.Quantity) });
           foreach(var item in avgGoodsQuantityByType)
            {
                
                Console.WriteLine("Type: " + item.type + " , " + "Average Quantity: " + item.avgQuantity );
            }
        }

        public IEnumerable<Good> GetGoodsByPassedDays(int passedDays)
        {
            DateTime oldDate = DateTime.Now.Subtract(new TimeSpan(passedDays, 0, 0, 0, 0));
            
            var goodsByPassedDays = warehouseContext.Goods.Where(g=>g.DeliveryDate < oldDate);
            return goodsByPassedDays;
        }

        public IEnumerable<Good> GetGoodsBySupplier(int supplierId)
        {
            var listOfGoodsBySupplier = warehouseContext.Goods.Where(g => g.SupplierId == supplierId);
            return listOfGoodsBySupplier;
        }

        public IEnumerable<Good> GetGoodsByType(int typeId)
        {
            var listOfGoodsByType = warehouseContext.Goods.Where(g => g.TypeId == typeId);
            return listOfGoodsByType;
        }

        public Good GetMaxCostGood()
        {
            var maxCost = warehouseContext.Goods.Max(g => g.Cost);
            var maxCostGood = warehouseContext.Goods.FirstOrDefault(g => g.Cost == maxCost);
            return (Good)maxCostGood;
        }

        public Good GetMaxQuantityGood()
        {
            var maxQuantity = warehouseContext.Goods.Max(g => g.Quantity);
            var maxQuantityGood = warehouseContext.Goods.FirstOrDefault(g => g.Quantity == maxQuantity);
            return (Good)maxQuantityGood;
        }

        public Good GetMinCostGood()
        {
            var minCost = warehouseContext.Goods.Min(g => g.Cost);
            var minCostGood = warehouseContext.Goods.FirstOrDefault(g => g.Cost == minCost);
            return (Good)minCostGood;
        }

        public Good GetMinQuantityGood()
        {
            var minQuantity = warehouseContext.Goods.Min(g => g.Quantity);
            var minQuantityGood = warehouseContext.Goods.FirstOrDefault(g => g.Quantity == minQuantity);
            return (Good)minQuantityGood;
        }

        public Good GetTheOldestGood()
        {
            var oldestGood = warehouseContext.Goods.Min(g => g.DeliveryDate);
            return warehouseContext.Goods.FirstOrDefault(g => g.DeliveryDate == oldestGood);
        }
    }
}
