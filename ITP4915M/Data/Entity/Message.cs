using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITP4915M.Data.Entity
{

    public class Message
    {
        public string Id { get; set; }
        public string _senderId { get; set; }
        public virtual Account sender { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public virtual ICollection<Staff_Message> staff_messages { get; set; }
    }
}