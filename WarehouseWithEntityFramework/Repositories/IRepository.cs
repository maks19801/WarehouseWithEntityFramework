﻿using System.Collections.Generic;
using WarehouseWithEntityFramework.Entities;

namespace WarehouseWithEntityFramework.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
