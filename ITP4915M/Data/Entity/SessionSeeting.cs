using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{
    public class SessionSetting
    {
        public string ID { get; set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumOfAppointments { get; set; }
        
    }
}