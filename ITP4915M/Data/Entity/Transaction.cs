using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

        public class Transaction
    {
        public string ID { get; set;}
        public string _salesOrderId { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}