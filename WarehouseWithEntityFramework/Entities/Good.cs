using System;

#nullable disable

namespace WarehouseWithEntityFramework.Entities
{
    public partial class Good:BaseEntity
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

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + TypeId + "\t" + SupplierId + "\t" + Quantity + "\t" + Cost + "\t" + DeliveryDate;
        }
    }
}
