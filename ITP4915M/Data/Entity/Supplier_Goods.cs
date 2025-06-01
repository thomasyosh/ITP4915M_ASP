using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{
    public class Supplier_Goods
    {
        public string ID { get; set; }
        public string _supplierId { get; set;}
        [ForeignKey("_supplierId")]
        public virtual Supplier Supplier { get; set; }
        public string _goodsId { get; set;}
        [ForeignKey("_goodsId")]
        public virtual Goods Goods { get; set; }
        public double? Price { get; set; }
        public virtual ICollection<Supplier_Goods_Stock> Supplier_Goods_Stocks { get; set; }
        public virtual ICollection<PurchaseOrder_Supplier_Goods> PurchaseOrder_Supplier_Goodss { get; set; }
    }
}