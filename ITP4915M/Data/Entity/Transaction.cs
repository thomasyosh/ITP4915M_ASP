using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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