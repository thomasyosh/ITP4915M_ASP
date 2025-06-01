using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Staff
    {
        public Staff()
        {
        }
        
    public string Id {get; set; }
    public string? _AccountId {get; set; }
    [ForeignKey("_AccountId")]
    public virtual Account? acc { get; set; }
    public string _departmentId {get; set; }
    [ForeignKey("_departmentId")]
    public virtual Department department { get; set; }
    public string _positionId {get; set; }
    [ForeignKey("_positionId")]
    public virtual Position position { get; set; }
    public string? _warehouseId {get; set; }
    [ForeignKey("_warehouseId")]
    public virtual Warehouse? warehouse { get; set; }
    public string? _storeId {get; set; }
    [ForeignKey("_storeId")]
    public virtual Store? store { get; set; }
    public string? _teamId {get; set; }
    [ForeignKey("_teamId")]
    public virtual Team? team { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char? Sex {get; set;}
    public short? Age {get; set;}
    public string? Phone { get; set;}

    }
}