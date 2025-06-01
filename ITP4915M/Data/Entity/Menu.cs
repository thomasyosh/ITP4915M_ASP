using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Permission> permissions { get; set; }
    }
}