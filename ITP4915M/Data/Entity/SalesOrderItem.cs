using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{
    public class SalesOrderItem
    {
        public string Id { get; set; }
        public string _salesOrderId { get; set; }
        [ForeignKey("_salesOrderId")]
        public virtual SalesOrder SalesOrder { get; set; }
        public string _supplierGoodsStockId { get; set; }
        [ForeignKey("_supplierGoodsStockId")]
        public virtual Supplier_Goods_Stock SupplierGoodsStock { get; set; }
        public int Quantity { get; set; }
        public string? _bookingOrderId { get; set; }
        [ForeignKey("_bookingOrderId")]
        public virtual BookingOrder? BookingOrder { get; set; }
        public double Price { get; set; }
        public virtual List<SalesOrderItem_Appointment>? SaleOrderItem_Appointment { get; set; }
    }
}