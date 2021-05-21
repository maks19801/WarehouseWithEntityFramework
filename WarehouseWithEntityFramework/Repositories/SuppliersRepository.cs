using WarehouseWithEntityFramework.Entities;
using System.Linq;

namespace WarehouseWithEntityFramework.Repositories
{
    public class SuppliersRepository : Repository<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository() : base()
        {

        }
        public Supplier GetSupplierInfoWithMaxQuantityOfGoods()
        {
            var maxQuantityGoodsSupplier = warehouseContext.Goods.GroupBy(g => g.Supplier.Name)
                                           .Select(g => new { supplier = g.Key, quantity = g.Sum(g => g.Quantity) })
                                           .OrderBy(g=>g.quantity)
                                           .LastOrDefault();
            var supplier = warehouseContext.Suppliers.FirstOrDefault(s => s.Name == maxQuantityGoodsSupplier.supplier);
            return supplier;
        }

        public Supplier GetSupplierInfoWithMinQuantityOfGoods()
        {
            var minQuantityGoodsSupplier = warehouseContext.Goods.GroupBy(g => g.Supplier.Name)
                                           .Select(g => new { supplier = g.Key, quantity = g.Sum(g => g.Quantity) })
                                           .OrderBy(g => g.quantity)
                                           .FirstOrDefault();
            var supplier = warehouseContext.Suppliers.FirstOrDefault(s => s.Name == minQuantityGoodsSupplier.supplier);
            return supplier;
        }
    }
}
