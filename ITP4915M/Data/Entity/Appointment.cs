using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class Appointment
    {
        public string ID { get; set;}
        public string? _sessionId { get; set;}
        public virtual Session? Session { get; set; }
        public string _departmentId { get; set;}
        public virtual Department Department { get; set; }
        public string? _teamId { get; set;}
        public virtual Team? Team { get; set; }

        public string _customerId { get; set;}
        public virtual Customer Customer { get; set; }

        public virtual List<SalesOrderItem_Appointment> SaleOrderItem_Appointments { get; set; }
    }
}