using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Warehouse
    {
        public string ID { get; set;}
        public string _locationID { get; set; }
        [ForeignKey("_locationID")]
        public virtual Location Location { get; set; }
    }
}