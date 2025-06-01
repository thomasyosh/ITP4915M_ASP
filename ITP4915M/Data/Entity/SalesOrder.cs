using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class SalesOrder
    {
        public string ID { get; set; }
        public string _creatorId { get; set; }
        public virtual Staff User { get; set; }
        public string _operatorId { get; set; }
        public virtual Staff Operator { get; set; }
        public string _storeId { get; set; }
        public virtual Store Store { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public SalesOrderStatus Status { get; set; } 
        public virtual List<SalesOrderItem> Items { get; set; }
    }

    public enum SalesOrderStatus
    {
        Placed,
        PendingDelivery,
        Delivering,
        Delivered,
        PendingInstall,
        Installing,
        Installed,
        Completed,
        Cancelled,
        Refunded,
        Booking
    }
}