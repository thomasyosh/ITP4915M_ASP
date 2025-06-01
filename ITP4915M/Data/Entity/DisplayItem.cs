using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

   public class DisplayItem
    {
        public string ID { get; set;}
        public string _goodsId { get; set;}
        [ForeignKey("_goodsId")]
        public virtual Goods Goods { get; set; }
        public string _locationId { get; set;}
        [ForeignKey("_locationId")]
        public virtual Location Location { get; set; }
        public string _supplierId { get; set;}
        [ForeignKey("_supplierId")]
        public virtual Supplier Supplier { get; set; }
        public DisplayItemStatus Status { get; set; }
    }

    public enum DisplayItemStatus
    {
        Displaying,
        Sold
    }
}