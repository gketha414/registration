using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreRegistration.Models.ViewModels
{
    public class EmergencyContactViewModel
    {
        [NotMapped]
        public bool EmergencySkip { get; set; }
        public EmergencyContact EmergencyContactOne { get; set; }
        public EmergencyContact EmergencyContactTwo { get; set; }
        public EmergencyContact EmergencyContactThree { get; set; }
    }

    public class EmergencyContactView
    {
        public int PersonID { get; set; }
        [Display(Name = "Nearest Relative Name")]
        public string Nearest_Relative_Name { get; set; }
        public string Relationship { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Display(Name = "State")]
        public string StateProvince { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> ZipCode { get; set; }
        [Display(Name = "Contact Phone")]
        public Nullable<long> Contact_Phone { get; set; }
    }
}
