using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class AccidentDetailViewModel
    {
        public int PersonID { get; set; }
        [Display(Name = "Accident Type")]
        public short AccidentTypeID { get; set; }
        [Display(Name = "Date Of Accident")]
        public string DateOfAccident { get; set; }
        [Display(Name = "Time Of Accident")]
        public string TimeOfAccident { get; set; }
        public string Location { get; set; }
    }
}
