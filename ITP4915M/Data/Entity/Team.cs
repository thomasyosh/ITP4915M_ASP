using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Team
    {
        public Team()
        {
        }
        
        public string ID { get; set;}
        public string _departmentId { get; set;}
        public virtual Department Department { get; set; }
        public string Name { get; set; }

    }
}