using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

   [Table("BookingOrder")]
    public class BookingOrder
    {
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        public string ID { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        public string _customerId { get; set; }

        [ForeignKey("_customerId")]
        public virtual Customer Customer { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        public string? _appointmentId { get; set; }

        [ForeignKey("_appointmentId")]
        public virtual Appointment? Appointment { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Remarks { get; set; }
    }
}