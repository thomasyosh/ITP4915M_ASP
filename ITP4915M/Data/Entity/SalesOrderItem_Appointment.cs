using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

        public class SalesOrderItem_Appointment
    {
        public string _salesOrderItemId { get; set; }
        public virtual SalesOrderItem SalesOrderItem { get; set; }
        public string _appointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}