using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class BookingOrder
    {
        public string ID { get; set; }
        public string _customerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string? _appointmentId { get; set; }
        public virtual Appointment? Appointment { get; set; }
        public string? Remarks { get; set; }
    }
}