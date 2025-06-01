using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Staff_Message
    {
        public string _messageId { get; set; }
        public virtual Message message { get; set; }
        public string _receiverId { get; set; }
        public StaffMessageStatus Status { get; set; }
        public virtual Account receiver { get; set; }
    }

    public enum StaffMessageStatus
    {
        Read,
        Received,
        Unreceived
    }
}