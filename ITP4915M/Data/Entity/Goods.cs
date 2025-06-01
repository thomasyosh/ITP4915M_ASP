using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

   public class Goods
    {
        public string Id { get; set;}
        public string _catalogueId { get; set; }
        public virtual Catalogue Catalogue { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? GTINCode { get; set; }
        public GoodsSize? Size { get; set; }
        public GoodsStatus Status { get; set; }
        public byte[]? Photo { get; set; }
        public virtual ICollection<Supplier_Goods> Supplier_Goods { get; set; }

    }

    public enum GoodsSize
    {
        Small ,
        Medium ,
        Large 
    }

    public enum GoodsStatus 
    {
        Selling,
        PhasingOut,
        StopSelling
    }
}