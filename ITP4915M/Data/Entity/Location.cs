using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Location
    {
        public string Id { get; set; }
        public string Loc { get; set; }
        public string? Name { get; set; }
    }
}