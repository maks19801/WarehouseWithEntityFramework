using System;
using System.Collections.Generic;

#nullable disable

namespace WarehouseWithEntityFramework.Entities
{
    public partial class Supplier:BaseEntity
    {
        public Supplier()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public override string ToString()
        {
            return Id + "\t" + Name;
        }
    }
}
