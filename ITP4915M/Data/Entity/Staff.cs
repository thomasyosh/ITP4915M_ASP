using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Staff
    {
        public Staff()
        {
        }
        
    public string Id {get; set; }
    public string? _AccountId {get; set; }
    public virtual Account? acc { get; set; }
    public string _departmentId {get; set; }
    public virtual Department department { get; set; }
    public string _positionId {get; set; }
    public virtual Position position { get; set; }
    public string? _warehouseId {get; set; }
    public virtual Warehouse? warehouse { get; set; }
    public string? _storeId {get; set; }
    public virtual Store? store { get; set; }
    public string? _teamId {get; set; }
    public virtual Team? team { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char? Sex {get; set;}
    public short? Age {get; set;}
    public string? Phone { get; set;}

    }
}