using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

   public class Customer
    {
        public string ID { get; set;}
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
    }
}