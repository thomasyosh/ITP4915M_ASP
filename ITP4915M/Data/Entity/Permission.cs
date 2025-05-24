using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Permission
    {
        public string _menuId { get; set; }
        public virtual Menu menu { get; set; }  
        public string _positionId { get; set; } 
        public virtual Position position { get; set; } 
        public bool? read { get; set; }
        public bool? write { get; set; }
        public bool? delete { get; set; }

    }
}