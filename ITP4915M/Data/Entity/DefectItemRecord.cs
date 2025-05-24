using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class DefectItemRecord
    {
        public string ID { get; set;}
        public string _supplierGoodsStockId { get; set; }
        public virtual Supplier_Goods_Stock SupplierGoodsStock { get; set; }
        public int Quantity { get; set; } = 1;
        public string? _salesOrderId { get; set; }
        public virtual SalesOrder? SalesOrder { get; set; }
        public string _creatorId { get; set; }
        public virtual Staff User { get; set; }
        public string _operatorId { get; set; }
        public virtual Staff Operator { get; set; }
        public DefectItemRecordStatus Status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? Remark { get; set; }
        public DefectItemHandleStatus HandleStatus { get; set; }
        public string? _customerId { get; set; }
        public virtual Customer? customer { get; set; }
        public string CollectAddress { get; set; }
    }
    public enum DefectItemHandleStatus
    {
        Refund,
        Exchange
    }

    public enum DefectItemRecordStatus 
    {
        Pending,
        Handling,
        Returned
    }
}