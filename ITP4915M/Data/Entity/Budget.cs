using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ITP4915M.Data.Entity
{

    public class Budget
    {
        public Budget()
        {
        }
        
        public string ID { get; set;}
        public string _operatorId { get; set; }
        public virtual Staff Operator { get; set; }
        public decimal Amount { get; set; }
        public BudgetStatus Status { get; set; }
        public string Remarks { get; set; }
        public DateTime ResetDate { get; set; }

        public enum BudgetStatus
            {
                Normal,
                Lock,
                Danger
            }

    }
}