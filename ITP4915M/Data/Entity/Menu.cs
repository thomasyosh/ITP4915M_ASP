using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Permission> permissions { get; set; }
    }
}