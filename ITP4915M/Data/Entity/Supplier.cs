using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Supplier
    {
        public string ID { get; set;}
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Supplier_Goods> Supplier_Goods { get; set; }
    }
}