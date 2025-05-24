using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Position
    {
        public Position()
        {
        }
        
        public string Id { get; set; }
        public string _departmentId { get; set; }
        public virtual Department department { get; set; }
        public string? jobTitle { get; set; } = "admin";
        public virtual ICollection<Permission> permissions { get; set; }

    }
}