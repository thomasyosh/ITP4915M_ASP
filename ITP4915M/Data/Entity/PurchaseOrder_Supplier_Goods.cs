using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class PurchaseOrder_Supplier_Goods
    {
        public string _purchaseOrderId { get; set;}
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public string _supplierGoodsId { get; set;}
        public virtual Supplier_Goods Supplier_Goods { get; set; }
        public uint Quantity { get; set; }
        public uint ReceivedQuantity { get; set; }
    }
}