namespace ITP4915M.Data.Dto
{
    public class ReceiveMessageDto
    {
        public string senderName { get; set; }
        public string sentDate { get; set; }

        public string Title { get; set; }
        public string content { get; set; }
        public string id { get; set; }
        public bool isRead { get; set; }
    }

    public class SendMessageDto 
    {
        public List<string> receiver { get; set; } // the account id -.- // NO!!!!!!!!!!!!!!!!!!! // this is UserName // fuck this shit i am out
        public string Title { get; set; }
        public string content { get; set; }
    }
}