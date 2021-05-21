using System.Linq;
namespace WarehouseWithEntityFramework.Repositories
{
    public class TypesOfGoodsRepository : Repository<TypesOfGood>, ITypesOfGoodsRepository
    {
        public TypesOfGood GetTypeInfoWithMaxQuantityOfGoods()
        {
            var maxQuantityGoodsType = warehouseContext.Goods.GroupBy(g => g.Type.Type)
                                       .Select(g => new { type = g.Key, quantity = g.Sum(g => g.Quantity) })
                                       .OrderBy(g => g.quantity)
                                       .LastOrDefault();
            var type = warehouseContext.TypesOfGoods.FirstOrDefault(s => s.Type == maxQuantityGoodsType.type);
            return type;
        }

        public TypesOfGood GetTypeInfoWithMinQuantityOfGoods()
        {
            var minQuantityGoodsType = warehouseContext.Goods.GroupBy(g => g.Type.Type)
                                       .Select(g => new { type = g.Key, quantity = g.Sum(g => g.Quantity) })
                                       .OrderBy(g => g.quantity)
                                       .FirstOrDefault();
            var type = warehouseContext.TypesOfGoods.FirstOrDefault(s => s.Type == minQuantityGoodsType.type);
            return type;
        }
    }
}
