namespace ITP4915M.AppLogic.Models
{
    using ITP4915M.Data.Dto;

    public class MessageModel
    {
        
    }

    public class ReceiveMessageModel
    {
        public short messageReceived { get; set; }
        public List<ReceiveMessageDto> messages { get; set; }
    }
}