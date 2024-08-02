namespace PreRegistration.Models.ViewModels
{
    public class MailViewModel
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Recipient { get; set; }
        public string EmailAddrFrom { get; set; }
        public int FormId { get; set; }
        public string AppName { get; set; }
    }
}
