using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Account
    {
        public Account()
        {
        }
        
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string Status { get; set; }
    public string _StaffId {get; set; }
    public virtual Staff Staff { get; set; }
    public int LoginFailedCount { get; set; }
    public DateTime? LoginFailedAt { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime? unlockDate { get; set; }
    public byte[]? Icon { get; set; }

    }
}