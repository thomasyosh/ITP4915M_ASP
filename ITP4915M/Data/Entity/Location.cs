using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Location
    {
        public string Id { get; set; }
        public string Loc { get; set; }
        public string? Name { get; set; }
    }
}