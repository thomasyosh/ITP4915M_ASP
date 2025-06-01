using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Permission
    {
        public string _menuId { get; set; }
        [ForeignKey("_menuId")]
        public virtual Menu menu { get; set; }  
        public string _positionId { get; set; } 
        [ForeignKey("_positionId")]
        public virtual Position position { get; set; } 
        public bool? read { get; set; }
        public bool? write { get; set; }
        public bool? delete { get; set; }

    }
}