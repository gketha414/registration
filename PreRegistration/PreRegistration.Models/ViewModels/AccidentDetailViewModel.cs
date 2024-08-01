namespace PreRegistration.Models.ViewModels
{
    public class AccidentDetailViewModel
    {
        public int PersonID { get; set; }
        public short AccidentTypeID { get; set; }
        public string DateOfAccident { get; set; }
        public string TimeOfAccident { get; set; }
        public string Location { get; set; }
    }
}
