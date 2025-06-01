using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class  RestockRequest_Supplier_Goods_Stock
    {
        public string _restockRequestId { get; set;}
        [ForeignKey("_restockRequestId")]
        public virtual RestockRequest RestockRequest { get; set; }
        public string _supplierGoodsStockId { get; set;}
        [ForeignKey("_supplierGoodsStockId")]
        public virtual Supplier_Goods_Stock Supplier_Goods_Stock { get; set; }
        public uint _quantity { get; set; }
        public uint _quantityReceived { get; set; }
    }
}