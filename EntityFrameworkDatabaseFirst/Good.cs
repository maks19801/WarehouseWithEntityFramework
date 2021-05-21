using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDatabaseFirst
{
    public partial class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual TypesOfGood Type { get; set; }
    }
}
