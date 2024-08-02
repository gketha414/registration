using System;

namespace PreRegistration.Models.ViewModels
{
    public class EmergencyContactViewModel
    {
        public int PersonID { get; set; }
        public string Nearest_Relative_Name { get; set; }
        public string Relationship { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public Nullable<long> ZipCode { get; set; }
        public Nullable<long> Contact_Phone { get; set; }
    }
}
