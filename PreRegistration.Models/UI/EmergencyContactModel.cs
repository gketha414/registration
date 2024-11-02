using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.UI
{
    public class EmergencyContactModel
    {
        public int PersonID { get; set; }
        [Display(Name = "Emergency Contact Name")]
        public string Nearest_Relative_Name { get; set; }
        [Display(Name = "Relationship")]
        public string Relationship { get; set; }
        public string Address { get; set; }
        [Display(Name = "Emergency Contact Phone")]
        public Nullable<long> Contact_Phone { get; set; }
    }
}
