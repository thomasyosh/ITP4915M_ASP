using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{
    public class SalesOrderItem
    {
        public string Id { get; set; }
        public string _salesOrderId { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public string _supplierGoodsStockId { get; set; }
        public virtual Supplier_Goods_Stock SupplierGoodsStock { get; set; }
        public int Quantity { get; set; }
        public string? _bookingOrderId { get; set; }
        public virtual BookingOrder? BookingOrder { get; set; }
        public double Price { get; set; }
        public virtual List<SalesOrderItem_Appointment>? SaleOrderItem_Appointment { get; set; }
    }
}