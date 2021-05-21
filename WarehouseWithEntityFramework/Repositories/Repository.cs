using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using WarehouseWithEntityFramework.Entities;

namespace WarehouseWithEntityFramework.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity, new()
    {
        public WarehouseContext warehouseContext;
        public Repository()
        {
            warehouseContext = new WarehouseContext();
        }
        public void Add(T entity)
        {
            warehouseContext.Add(entity);
            warehouseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = warehouseContext.Set<T>().Find(id);
            warehouseContext.Remove(result);
            warehouseContext.SaveChanges();
        }

        public void Dispose()
        {
            warehouseContext.Dispose();
        }

        public T Get(int Id)
        {
            var result = warehouseContext.Set<T>().Find(Id);
            return result;
        }
        public IEnumerable<T> Get()
        {
            var result = warehouseContext.Set<T>().ToList();
            return result;  
        }
       
        public void Update(T entity)
        {
            warehouseContext.Update(entity);
            warehouseContext.SaveChanges();
        }
    }
}
