using System;
using WarehouseWithEntityFramework.Entities;

namespace WarehouseWithEntityFramework.Repositories
{
    public interface ISuppliersRepository: IRepository<Supplier>, IDisposable
    {
        public Supplier GetSupplierInfoWithMaxQuantityOfGoods();
        public Supplier GetSupplierInfoWithMinQuantityOfGoods();
    }
}
