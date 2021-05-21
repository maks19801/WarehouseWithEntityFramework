using System;
using WarehouseWithEntityFramework.Entities;

namespace WarehouseWithEntityFramework.Repositories
{
    public interface ITypesOfGoodsRepository: IRepository<TypesOfGood>, IDisposable
    {
        public TypesOfGood GetTypeInfoWithMaxQuantityOfGoods();
        public TypesOfGood GetTypeInfoWithMinQuantityOfGoods();
    }
}
