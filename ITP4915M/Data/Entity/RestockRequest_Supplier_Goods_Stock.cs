using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class  RestockRequest_Supplier_Goods_Stock
    {
        public string _restockRequestId { get; set;}
        public virtual RestockRequest RestockRequest { get; set; }
        public string _supplierGoodsStockId { get; set;}
        public virtual Supplier_Goods_Stock Supplier_Goods_Stock { get; set; }
        public uint _quantity { get; set; }
        public uint _quantityReceived { get; set; }
    }
}