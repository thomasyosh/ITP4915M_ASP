using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

   [Table("Catalogue")]
    public class Catalogue
    {
        [Key]
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string Id { get; set;}

        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        [AppLogic.Attribute.Translatable]
        public string Name { get; set; }
    }
}