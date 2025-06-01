using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("_budgetId")]
        public virtual Budget? budget { get; set; }
        public virtual ICollection<Staff> staffs { get; set; }
        public virtual ICollection<Team> teams { get; set; }

    }
}