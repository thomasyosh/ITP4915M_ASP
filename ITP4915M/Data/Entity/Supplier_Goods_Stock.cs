using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{
    public class Supplier_Goods_Stock
    {
        public string Id  { get; set; }
        public string _locationId { get; set; }
        public virtual Location Location { get; set; }
        public string _supplierGoodsId { get; set;}
        public virtual Supplier_Goods Supplier_Goods { get; set; }
        public int Quantity { get; set; }
        public int MaxLimit { get; set; }
        public int MinLimit { get; set; }
        public int ReorderLevel { get; set; }
        public bool isSoftDeleted { get; set; }
        public virtual ICollection<DefectItemRecord> DefectItemRecords { get; set; }
        public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; }
        public virtual ICollection<RestockRequest_Supplier_Goods_Stock> RestockRequest_Supplier_Goods_Stocks { get; set; }
    
    }
}