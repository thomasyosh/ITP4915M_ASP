using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Store
    {
        public string ID { get; set;}
        public string _locationID { get; set; }
        public virtual Location Location { get; set; }

    }
}