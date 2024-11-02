using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.UI
{
    public class AccidentDetailModel
    {
        public int PersonID { get; set; }
        public short AccidentTypeID { get; set; }
        [Display(Name = "Accident Type")]
        public string AccidentType { get; set; }
        [Display(Name = "Date Of Accident")]
        public string DateOfAccident { get; set; }
        [Display(Name = "Time Of Accident")] 
        public string TimeOfAccident { get; set; }
        [Display(Name = "Place of Accident")]
        public string Location { get; set; }
    }
}
