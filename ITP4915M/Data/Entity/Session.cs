using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{
    public class Session
    {
        public string ID { get; set;}
        public string _departmentId { get; set;}
        public virtual Department Department { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public int NumOfAppointments { get; set; }
    }
}