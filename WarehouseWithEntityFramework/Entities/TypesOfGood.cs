using System;
using System.Collections.Generic;
using WarehouseWithEntityFramework.Entities;

#nullable disable

namespace WarehouseWithEntityFramework
{
    public partial class TypesOfGood:BaseEntity
    {
        public TypesOfGood()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public override string ToString()
        {
            return Id + "\t" + Type;
        }
    }
}
