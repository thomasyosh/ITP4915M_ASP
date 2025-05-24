using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class DayOffRecord
    {
        public string ID { get; set;}
        public string _staffID { get; set; }
        public virtual Staff Staff { get; set; }
        public DateTime OffDate { get; set; }
        public string Reason { get; set; }
    }
}