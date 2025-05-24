using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class DisplayItem
    {
        public string ID { get; set;}
        public string _goodsId { get; set;}
        public virtual Goods Goods { get; set; }
        public string _locationId { get; set;}
        public virtual Location Location { get; set; }
        public string _supplierId { get; set;}
        public virtual Supplier Supplier { get; set; }
        public DisplayItemStatus Status { get; set; }
    }

    public enum DisplayItemStatus
    {
        Displaying,
        Sold
    }
}