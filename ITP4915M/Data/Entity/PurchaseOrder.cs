using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class PurchaseOrder
    {
        public string ID { get; set;}
        public string _createrId { get; set;}
        [ForeignKey("_createrId")]
        public virtual Staff Creater { get; set; }
        public string? _operatorId { get; set;}
        [ForeignKey("_operatorId")]
        public virtual Staff? Operator { get; set; }
        public string _supplierId { get; set;}
        [ForeignKey("_supplierId")]
        public virtual Supplier Supplier { get; set; }
        public string _warehouseId { get; set; }
        [ForeignKey("_warehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime OperateTime { get; set; }
        public virtual PurchaseOrderStatus Status { get; set; }
        public virtual List<PurchaseOrder_Supplier_Goods> Items { get; set; }
    }

    public enum PurchaseOrderStatus
    {
        Pending,
        PendingApproval,
        Rejected,
        Cancelled,
        Approved,
        SentToSupplier,
        Inbound,
        Completed
    }
}