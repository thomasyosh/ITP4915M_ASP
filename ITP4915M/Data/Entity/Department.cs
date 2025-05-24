using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Department
    {
        public Department()
        {
        }
        
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? _budgetId { get; set; }
        public virtual Budget? budget { get; set; }
        public virtual ICollection<Staff> staffs { get; set; }
        public virtual ICollection<Team> teams { get; set; }

    }
}