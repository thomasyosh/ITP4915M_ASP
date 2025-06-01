using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class RestockRequest
    {
        public string ID { get; set;}
        public string _createrId { get; set;}
        [ForeignKey("_createrId")]
        public virtual Staff Creater { get; set; }
        public string _operatorId { get; set;}
        [ForeignKey("_operatorId")]
        public virtual Staff Operator { get; set; }
        public string _locationId { get; set; }
         [ForeignKey("_locationId")]
        public virtual Location Location { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime OperateTime { get; set; }
        public RestockRequestStatus Status { get; set; }
        public virtual List<RestockRequest_Supplier_Goods_Stock> Items { get; set; }        
    }

    public enum RestockRequestStatus
    {
        Pending,
        PendingApproval,
        Approved,
        Rejected,
        Handling,
        Completed,
        Cancelled,

    }
}