using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Warehouse
    {
        public string ID { get; set;}
        public string _locationID { get; set; }
        public virtual Location Location { get; set; }
    }
}